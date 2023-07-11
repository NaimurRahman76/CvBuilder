using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAccountRepository
    {
        Task<String> Login(User user);
        Task SignUp(User user);
        Task<String> Confirm(String email, int validationCode);
        Task<bool> Check(string email);
        Task<string> GetName(string email);
        Task<long>GetId(string email);
    }
}
