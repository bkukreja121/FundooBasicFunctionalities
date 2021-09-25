using BusinessLibrary.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Services
{
    public class UserBL : IUserBL
    {
        private IUserRL _userRL;
        public UserBL(IUserRL userRL)
        {
            this._userRL = userRL;
        }

        public bool Register(RegisterModel user)
        {
            try
            {
                return this._userRL.Register(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        public User Get(long id)
        {
            try
            {
                return this._userRL.Get(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel Login(LoginModel loginModel)
        {
            try
            {
                return this._userRL.Login(loginModel);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return this._userRL.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            try
            {
                return this._userRL.ResetPassword(resetPasswordModel, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                return this._userRL.ForgotPassword(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

       
    }

}
