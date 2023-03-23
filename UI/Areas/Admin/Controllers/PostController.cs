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

        public ActionResult AddPost()
        {
            PostDTO dto = new PostDTO();
            return View(dto);
        }
        
        [HttpPost]
        public ActionResult AddPost(PostDTO model)
        {
            if (ModelState.IsValid)
            {
                SessionDTO session = (SessionDTO)Session["UserInfo"];
                if (bll.AddPost(model, session))
                {
                    ViewBag.ProcessState = "Success";
                    ModelState.Clear();
                    model = new PostDTO();
                }
                else
                {
                    ViewBag.ProcessState = "Empty";
                }
            }
            return View(model);
        }
        
        public ActionResult DeletePost(int id)
        {
            SessionDTO session = (SessionDTO)Session["UserInfo"];
            bll.DeletePost(id, session);
            return RedirectToAction("PostList", "Post");
        }
        
        public ActionResult UpdatePost(int id)
        {
            PostDTO model = new PostDTO();
            model = bll.GetPostWithID(id);
            model.isUpdate = true;
            return View(model);
        }
    }
}