using BusinessLogic.IServices;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;

namespace CV_Maker.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public AccountController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView loginInfo)
        {
            if(!ModelState.IsValid) { return View(loginInfo); }
            var result =await _unitOfService.AccountService.Login(loginInfo);
            if(result.Length==0)
            {
                var name =await _unitOfService.AccountService.GetName(loginInfo.Email);
                var userId=await _unitOfService.AccountService.GetId(loginInfo.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, loginInfo.Email),
                    new Claim(ClaimTypes.Name,name)
                };
                var identity=new ClaimsIdentity(claims,"MyCookieAuth");
                var claimsPrincipal= new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginInfo.RememberMe,
                };
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                HttpContext.Session.SetInt32("userId", (int)userId);
                return RedirectToAction("Index", "Home");
            }
            ViewData["error"] = result.ToString();
            return View(loginInfo);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpView signUpView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.AccountService.SignUp(signUpView);
                    await _unitOfService.BasicInfoService.Save();
                    return RedirectToAction("ConfirmUser", new {email=signUpView.Email});
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("email", "This email already exist");
                    return View(signUpView);
                }
                
            }
            else
            {
                return View(signUpView);
            }
        }
        public IActionResult ConfirmUser(string email)
        {
            ViewBag.email=email;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUser(string email, int validationCode) 
        {
            try
            {
               await _unitOfService.AccountService.ConfirmUser(email, validationCode);
                await _unitOfService.CvService.Save();
                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                ViewData["error"]= ex.Message;
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }   
}
