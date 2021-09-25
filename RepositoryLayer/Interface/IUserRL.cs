


using CommonLayer.Model;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        ResponseModel Login(LoginModel loginModel);
        bool Register(RegisterModel user);
       
        bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId);

        ResponseModel ForgotPassword(ForgotPasswordModel model);




    }
}
