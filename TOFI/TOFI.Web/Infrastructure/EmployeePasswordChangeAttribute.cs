using System.Web.Mvc;
using System.Web.Routing;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Infrastructure
{
    public class EmployeePasswordChangeAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.User.IsInRole("employee"))
                {
                    var user = DependencyResolver.Current.GetService<IUserService>()
                        .GetUser(new UserQuery
                        {
                            Id = int.Parse(filterContext.HttpContext.User.Identity.GetUserId())
                        });
                    if (user.Value?.Auth.PasswordChangedUtc == null)
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Manage", action = "ChangePassword" }));
                        filterContext.Controller.TempData["PassNotChanged"] = true;
                    }
                }
            }
        }
    }
}