using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TOFI.TransferObjects.User.Queries;
using TOFI.Web.Infrastructure;
using TOFI.Web.Models;

namespace TOFI.Web.Controllers
{
    //[EmployeePasswordChange]
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
            if (User.IsInRole("employee") && !UserManager.IsEmailConfirmed(userId))
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
                if (User.IsInRole("employee") && !UserManager.IsEmailConfirmed(userId))
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
                    var res = await UserManager.IsEmailConfirmedAsync(userId);
                    if (!res) await UserManager.ConfirmEmailAsync(userId,
                        await UserManager.GenerateEmailConfirmationTokenAsync(User.Identity.GetUserId()));
                }
                ViewBag.Success = true;
                return View();
            }
            if (User.IsInRole("employee") && !UserManager.IsEmailConfirmed(userId))
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
        public async Task<ActionResult> ChangeEmail(ChangeEmailViewModel newEmail)
        {
            if (!ModelState.IsValid)
            {
                return View(newEmail);
            }
            var userService = DependencyResolver.Current.GetService<IUserService>();
            var user = userService
                    .GetUser(UserQuery.WithId(int.Parse(User.Identity.GetUserId()))).Value;
            if (user.Email == newEmail?.NewEmail)
            {
                ModelState.AddModelError("", "Это ваш текущий e-mail! Введите другой");
            }

            user.Email = newEmail.NewEmail;
            user.EmailConfirmed = false;
            userService.UpdateModel(user);

            var userId = User.Identity.GetUserId();
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userId, "Подтверждение аккаунта", "Для активации своего аккаунта перейдите, пожалуйста, по <a href=\"" + callbackUrl + "\">ссылке</a>");

            ViewBag.Success = true;
            return View();
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