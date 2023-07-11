using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _db;
        public AccountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> Confirm(string email, int validationCode)
        {
           var res=await _db.Users.FirstOrDefaultAsync(x => x.Email == email&& x.ConfirmationCode==validationCode);
            if (res == null) { return "Invalida code please check your email for the code"; }
            else
            {
                
                if (DateTime.Now<=res.Validity)
                {
                    res.IsEmailConfirmed = true;
                    return "success";
                }
                else
                {
                    return "Code Expired please send email again";
                }
            }
        }

        public async Task<string> Login(User user)
        {
            var res=await _db.Users.FirstOrDefaultAsync(x=>x.Email == user.Email && x.Password==user.Password);
            if (res == null) return "Email and password is incorrect";
            if (res.IsEmailConfirmed)
            {
                return "";
            }
            else {
                return "Email is not varified";
            }
        }

        public async Task SignUp(User user)
        {
            await _db.Users.AddAsync(user);
        }
        public async Task<bool> Check(string email)
        {
            var res = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (res == null) { return false; }
            return true;
        }
        public async Task<string>GetName(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user.Name.ToString();
        }
        public async Task<long> GetId(string email)
        {
           var user=await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(user != null) return user.Id;
            return 0;
        }
    }
}
