using System.Web.Mvc;
using DTO;

namespace UI.Areas.Admin.Models.Attributes
{
    public class LoginControl : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            SessionDTO session = (SessionDTO)ctx.Session["UserInfo"];
            if (session == null || session.UserID == 0)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
            }
        }
    }
}