
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
using RepositoryLayer.Entity;
using CommonLayer.Model;
using BusinessLibrary.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CommonLayer;

namespace FundooNotes.Controllers
{
    [Route("api/user")]

    [ApiController]
    public class UserController : Controller
    {
        
        public static IConfiguration _config;
        private IUserBL userBL;
        public UserController(IUserBL userBL, IConfiguration config)
        {
            this.userBL = userBL;
            _config = config;
        }




        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> user = userBL.GetAll();
            return Ok(user);
        }
       
      
        // POST: api/user
        [HttpPost]
        public IActionResult Register(RegisterModel user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }
            var result = userBL.Register(user);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "User successfully Registered" });
            }
            else
            {
                return this.BadRequest();
            }

        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginModel loginModel)
        {
            try
            {
                if (loginModel == null)
                {
                    return BadRequest("Employee is null.");
                }
                ResponseModel responseModel = userBL.Login(loginModel);

                if (responseModel == null)
                {
                    return NotFound("The User record couldn't be found.");
                }
                string token = GenerateJwtToken(responseModel.UserId, responseModel.Email);

                return this.Ok(new { success = true, message = "User successfully LoggedIn", data = responseModel, jwtToken = token });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }


        }

        [Authorize]
        [HttpGet("demo")]
        public IActionResult Demo()
        {
            return this.Ok(new { success = true, message = "HELLO" });
        }

        private static string GenerateJwtToken(long UserId, string EmailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("Id", UserId.ToString()));
            permClaims.Add(new Claim(ClaimTypes.Email, EmailId));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              permClaims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        [Authorize]
        [HttpPut("resetpassword")]
        public IActionResult ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (resetPasswordModel.newPassword == resetPasswordModel.confirmPassword)
                {
                    long userId = GetTokenId();
                    var result = userBL.ResetPassword(resetPasswordModel, userId);
                    if (result == true)
                    {
                        return this.Ok(new { success = true, message = "Password reset successfull" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = "Password not matching,Enter again!" });
                    }
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Password not matching,Enter again!" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }

        }

        public long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpPost("forgot/password")]

        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                ResponseModel response = userBL.ForgotPassword(model);
                if (response.FirstName == null && response.LastName == null)
                {
                    return this.NotFound(new { success = false, message = "The mail is not valid" });
                }
                else
                {
                    string token = GenerateJwtToken(response.UserId, response.Email);
                    new MsmqOperation().SendData(token);

                    return Ok(new { success = true, message = "The Reset Password  Link has been sent to you succesfully" });

                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }


    }

}