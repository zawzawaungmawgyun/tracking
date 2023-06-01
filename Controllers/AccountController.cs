using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Areas.Identity.Data;
using Tracking.Data;
using Tracking.Models;
using Tracking.Models.AccountViewModels;

namespace Tracking.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        //GET
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {   
             ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        HttpContext.Session.SetString("UserId", user.Id);

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User logged in.");
                        TempData["success"] = "Sucessfully Login!";
                        return RedirectToAction(nameof(TrackingController.Index), "Tracking");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
            return View(model);

        }


        //GET
        public IActionResult Register()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginUser model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var chkUser = await _userManager.FindByEmailAsync(model.Email);
                if (chkUser != null)
                {
                    ModelState.AddModelError(string.Empty, "User already exit.");
                    TempData["success"] = "User already exit.";
                    return Redirect("Register");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    LoginUser loginUser = new LoginUser();
                    loginUser.Id = user.Id;
                    loginUser.Email = model.Email;
                    loginUser.FirstName = model.FirstName;
                    loginUser.LastName = model.LastName;
                    loginUser.Password = model.Password;
                    loginUser.ConfirmPassword = model.ConfirmPassword;
                    _dbContext.LoginUser.Add(loginUser);
                    _dbContext.SaveChanges();

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    TempData["success"] = "Sucessfully created!";
                    return Redirect("Login");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

       

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(TrackingController.Index), "Tracking");
            }
        }

        #endregion 
    }
}
