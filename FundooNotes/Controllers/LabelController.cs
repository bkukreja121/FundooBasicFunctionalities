using BusinessLayer.Interface;
using BusinessLibrary.Interface;
using CommonLayer.Model.LabelModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/label")]

    [ApiController]
    public class LabelController : Controller
    {
       
        private ILabelBL _labelBL;
        public LabelController(ILabelBL labelBL)
        {
            _labelBL = labelBL;
           
        }

        [HttpPost("{Id}")]
        public IActionResult AddLabel(AddLabel addLabel,int Id)
        {
            var userId = GetTokenId();
            try
            {
                if (addLabel == null)
                {
                    return BadRequest("Employee is null.");
                }
                var result = _labelBL.AddLabel(addLabel, userId,Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Label Created Successfully" });
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }

        }
        [HttpPut("{labelId}/edit")]
        public IActionResult EditLabel(EditLabel editLabelModel, long labelId)
        {

            try
            {

                var result = _labelBL.EditLabel(editLabelModel, labelId);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Label Edited Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Label Updation Failed" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }

        }
        [HttpDelete("{labelId}")]
        public IActionResult DeleteLabel(long labelId)
        {
            try
            {
                Label label = _labelBL.Get(labelId);
                if (label == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }
                var result = _labelBL.DeleteLabel(label);

                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Label Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Label Deletion Failed" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }


        }

        [HttpGet]
        public IActionResult DisplayLabel()
        {
            long userId = GetTokenId();
            try
            {
                IEnumerable<LabelModel> labels = _labelBL.DisplayLabel(userId);
                return Ok(labels);
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        // Get UserID by JWT Token
        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        //Generate JWT Token
        //private static string GenerateJwtToken(long UserId, string EmailId)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var permClaims = new List<Claim>();
        //    permClaims.Add(new Claim("Id", UserId.ToString()));
        //    permClaims.Add(new Claim(ClaimTypes.Email, EmailId));

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      permClaims,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}