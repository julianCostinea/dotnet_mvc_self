﻿using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using DTO;

namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        UserBLL userbll = new UserBLL();

        // GET
        public ActionResult Index()
        {
            UserDTO dto = new UserDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Index(UserDTO model)
        {
            if (model.Username != null && model.Password != null)
            {
                UserDTO user = userbll.GetUserWithUsernameAndPassword(model);
                if (user.ID != 0)
                {
                    SessionDTO session = new SessionDTO();
                    session.UserID = user.ID;
                    session.Imagepath = user.Imagepath;
                    session.Namesurname = user.Name;
                    session.isAdmin = user.isAdmin;
                    HttpCookie cookie = new HttpCookie("Id");
                    cookie.Value = user.ID.ToString();
                    Response.Cookies.Add(cookie);
                    FormsAuthentication.SetAuthCookie(user.ID.ToString(), false);
                    Session.Add("UserInfo", session);
                    Session.Add("Id", user.ID);
                    LogBLL.AddLog(1, "Login", 12, session);
                    return RedirectToAction("Index", "Post");
                }

                ViewBag.ProcessState = General.Messages.GeneralError;

                return View(model);
            }

            return View(model);
        }
    }
}