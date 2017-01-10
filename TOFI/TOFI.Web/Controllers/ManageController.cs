using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TOFI.TransferObjects.User.Queries;
using TOFI.Web.Models;

namespace TOFI.Web.Controllers
{
    //[EmployeePasswordChange]
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUserService _userService;

        public ManageController(IUserService userService)
        {
            _userService = userService;
        }

        public ManageController(IUserService userService, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _userService = userService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var userId = User.Identity.GetUserId();
            if (CheckEmployeePasswordNotChanged())
                TempData["PassNotChanged"] = true;
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                if (CheckEmployeePasswordNotChanged())
                    TempData["PassNotChanged"] = true;
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                if (User.IsInRole("employee"))
                {
                    var user1 = _userService.GetUser(UserQuery.WithId(int.Parse(User.Identity.GetUserId()))).Value;
                    user1.Auth.PasswordChangedUtc = DateTimeOffset.Now;
                    _userService.UpdateModel(user1);
                }
                ViewBag.Success = true;
                return View();
            }
            if (CheckEmployeePasswordNotChanged())
                TempData["PassNotChanged"] = true;
            AddErrors(result);
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userService
                    .GetUser(UserQuery.WithId(int.Parse(User.Identity.GetUserId()))).Value;
            if (user.Email == model?.NewEmail)
            {
                ModelState.AddModelError("", "Это ваш текущий e-mail! Введите другой");
                return View(model);
            }

            user.Email = model.NewEmail;
            user.EmailConfirmed = false;
            _userService.UpdateModel(user);

            var userId = User.Identity.GetUserId();
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userId, "Подтверждение аккаунта", "Для активации своего аккаунта перейдите, пожалуйста, по <a href=\"" + callbackUrl + "\">ссылке</a>");

            ViewBag.Success = true;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AnotherConfirmationEmailSend()
        {
            var userId = User.Identity.GetUserId();
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userId, "Подтверждение аккаунта", "Для активации своего аккаунта перейдите, пожалуйста, по <a href=\"" + callbackUrl + "\">ссылке</a>");
           
            var user = _userService
                    .GetUser(UserQuery.WithId(int.Parse(User.Identity.GetUserId()))).Value;
            user.Auth.PasswordChangedUtc = DateTimeOffset.Now;
            _userService.UpdateModel(user);
            return RedirectToAction("ChangeEmail");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private bool CheckEmployeePasswordNotChanged()
        {
            if (!User.IsInRole("employee")) return false;
            var user = _userService.GetUser(UserQuery.WithId(int.Parse(User.Identity.GetUserId()))).Value;
            return user?.Auth?.PasswordChangedUtc == null;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user.HasPassword;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}