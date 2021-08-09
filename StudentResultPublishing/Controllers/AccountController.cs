using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace StudentResultPublishing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signinManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //var result = await createTestUser();
            /*if (result)
            {*/
                if (!ModelState.IsValid)
                {
                    return View(loginModel);
                }
                var user = await _userManager.FindByEmailAsync(loginModel.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                //add role if have
                _signinManager.SignInAsync(user,false);
                    return RedirectToAction(nameof(AdminController.Index), "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "invalid username and password");
                    return View();
                }
           /* }*/
            /*else
            {
                return View();
            }*/
        }

        private async Task<bool> createTestUser()
        {
            var user = new ApplicationUser
            {
                UserName = "akhil",
                Email = "Akhil@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };
            var password = "akhil";

            var result =await  _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
