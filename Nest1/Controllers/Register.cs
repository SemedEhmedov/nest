using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nest1.DAL;
using Nest1.Models;
using Nest1.ViewModels.Account;

namespace Nest1.Controllers
{
    public class Register : Controller
    {
        AppDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public Register(AppDBContext appDBContext,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _context = appDBContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserManager<AppUser> UserManager { get; }

        public IActionResult Registerr()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registerr(RegisterVm vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            JsonResult jsonResult = new JsonResult(vm);
            AppUser User = new AppUser();
            {
                User.UserName = vm.UserName;
                User.Email = vm.Email;
            }
            var result = await _userManager.CreateAsync(User,vm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
                return View();
            }
            _signInManager.SignInAsync(User,true);



            return RedirectToAction("Index", "Home");
        }
    }
}
