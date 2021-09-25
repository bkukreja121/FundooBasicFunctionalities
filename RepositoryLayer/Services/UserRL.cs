
using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        readonly UserContext _userContext;
        public UserRL(UserContext context)
        {
            _userContext = context;
        }
        public bool Register(RegisterModel user)
        {
            User userEntity = new User();
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.CreatedAt = DateTime.Now;
            _userContext.Users.Add(userEntity);
            int result=_userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void model()
        {

        }
       

        public ResponseModel ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                User user = _userContext.Users.FirstOrDefault(e => e.Email == model.Email);
                if ( user!= null)
                {
                    ResponseModel response = new ResponseModel();
                    response.Email = user.Email;
                    response.UserId = user.UserId;
                    response.FirstName = user.FirstName;
                    response.LastName = user.LastName;
                    return response;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       

        public User Get(long id)
        {
            return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public ResponseModel Login(LoginModel loginModel)
        {
           
            try
            {
                User user = _userContext.Users.FirstOrDefault(e => e.Email == loginModel.Email && e.Password==loginModel.Password);
                ResponseModel responseModel = new ResponseModel()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
                return responseModel;
            }
            catch (Exception ex )
            {

                throw;
            }
          
            
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            User user = _userContext.Users.FirstOrDefault(e => e.UserId == userId);

            try
            {

                user.Password = resetPasswordModel.newPassword;
                _userContext.Users.Update(user);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

    }
}
