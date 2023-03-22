using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using DTO;

namespace UI.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        PostBLL bll = new PostBLL();
        // GET
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult PostList()
        {
            List<PostDTO> list = bll.GetPostList();
            return View(list);
        }
    }
}