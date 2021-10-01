using BusinessLibrary.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;


namespace BusinessLibrary.Services
{
    using System.Collections.Generic;
    using RepositoryLayer.Interface;
    using System;
 
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
            catch (Exception )
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
            catch (Exception )
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
            catch(Exception )
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
            catch (Exception )
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
            catch (Exception )
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
            catch (Exception )
            {
                throw;
            }

        }

       
    }

}
