using JobPortal.BussinessLogicLayer.SeekerProfileService;
using JobPortal.BussinessLogicLayer.User;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices userService;
        

        public AccountController(IUserServices _userService)
        {
            userService = _userService;
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel user, string returnUrl)
        {
            var result = await userService.SignIn(user);

            if (result.Succeeded)
            {
                var role = await userService.GetUserRoleByEmailAsync(user.Email);
                if(role[0] == "jobrecruiter")
                {
                    
                    return RedirectToAction("Index", "Recruiter");
                }
                if(role[0] == "jobseeker")
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Seeker");
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            ViewBag.EmailExist = false;
            ViewBag.RegistrationOk = false;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SignUp(SignUpViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            if(!await userService.IsEmailExist(user.Email))
            {
                var result = await userService.SignUp(user);
                if(result.Succeeded)
                {
                  
                    ModelState.Clear();
                    ViewBag.EmailExist = false;
                    ViewBag.RegistrationOk = true;
                    return View();
                }
                else
                {
                    ViewBag.EmailExist = false;
                    ViewBag.RegistrationOk = false;
                    return View(user);
                }
            }

            ViewBag.EmailExist = true;
            ViewBag.RegistrationOk = false;
            return View();
           

            
            
        }
        public async Task<IActionResult> MyPanel()
        {
            var email =  User.FindFirst(ClaimTypes.Email)?.Value;

            var role = await userService.GetUserRoleByEmailAsync(email);
            if (role[0] == "jobrecruiter")
            {

                return RedirectToAction("Index", "Recruiter");
            }
            if (role[0] == "jobseeker")
            {
                return RedirectToAction("Index", "Seeker");
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await userService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
       
    }
}
