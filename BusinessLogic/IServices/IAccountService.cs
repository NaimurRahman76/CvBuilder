using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IAccountService
    {
        Task<String> Login(LoginView loginView);
        Task SignUp(SignUpView signupView);
        Task ConfirmUser(string email, int validationCode);
        Task<string>GetName(string email);
        Task<long>GetId(string email);
    }
}
