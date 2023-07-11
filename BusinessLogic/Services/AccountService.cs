using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Utility;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        public AccountService(IUnitOfRepository unitOfRepository,IMapper mapper, EmailService emailService)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
            _emailService = emailService;

        }

        public async Task ConfirmUser(string email, int validationCode)
        {
            var res=await _unitOfRepository.AccountRepository.Confirm(email, validationCode);
            if (res != "success") throw new Exception(res);
        }

        public async Task<String> Login(LoginView loginView)
        {
           var user= _mapper.Map<LoginView, User>(loginView);
            user.Password=PasswordUtility.Encrypt(loginView.Password);
          return await _unitOfRepository.AccountRepository.Login(user);
        }

        public async Task SignUp(SignUpView signupView)
        {
            var check =await _unitOfRepository.AccountRepository.Check(signupView.Email);
            if (check) throw new Exception("Email Already exist please login");
            var user=_mapper.Map<SignUpView, User>(signupView);
            user.Validity = DateTime.Now.AddMinutes(5);
            var rand=new Random();
            var secretCode = rand.Next(1000, 9999);
            user.ConfirmationCode = secretCode;
            _emailService.SendValidationCode(signupView.Email, secretCode);
            user.Password = PasswordUtility.Encrypt(user.Password);
            await _unitOfRepository.AccountRepository.SignUp(user);   
        }
        public async Task<string> GetName(string email)
        {
            return await _unitOfRepository.AccountRepository.GetName(email);
        }
        public async Task<long> GetId(string email)
        {
            var userId= await _unitOfRepository.AccountRepository.GetId(email);
            return userId;
        }
    }
}
