using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
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
            dto.Categories = CategoryBLL.GetCategoriesForDropdown();
            return View(dto);
        }
        
        [HttpPost]
        // [ValidateInput(false)]
        public ActionResult AddPost(PostDTO model)
        {
            if (model.PostImage == null)
            {
                ViewBag.ProcessState = General.Messages.ImageMissing;;
            }
            else if (ModelState.IsValid)
            {
                SessionDTO session = (SessionDTO)Session["UserInfo"];
                HttpPostedFileBase postedFile = model.PostImage;
                string fileName = "";
                string ext = Path.GetExtension(postedFile.FileName);
                if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                {
                    ViewBag.ProcessState = General.Messages.ExtensionError;
                    model.Categories = CategoryBLL.GetCategoriesForDropdown();
                    return View(model);
                }
                Bitmap PostImage = new Bitmap(postedFile.InputStream);
                Bitmap resizedImage = new Bitmap(PostImage, 200, 200);
                fileName = Guid.NewGuid() + postedFile.FileName;
                string path = Server.MapPath("~/Areas/Admin/Content/PostImages/" + fileName);
                resizedImage.Save(path);
                model.ImagePath = fileName;
                if (bll.AddPost(model, session))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new PostDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.EmptyArea;
                }
            }
            model.Categories = CategoryBLL.GetCategoriesForDropdown();
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
            model.Categories = CategoryBLL.GetCategoriesForDropdown();
            model.isUpdate = true;
            return View(model);
        }
        
        [HttpPost]
        public ActionResult UpdatePost(PostDTO model)
        {
            IEnumerable<SelectListItem> selectlist = CategoryBLL.GetCategoriesForDropdown();
            if (ModelState.IsValid)
            {
                SessionDTO session = (SessionDTO)Session["UserInfo"];
                if (bll.UpdatePost(model, session))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.EmptyArea;
                }
            }
            model = bll.GetPostWithID(model.ID);
            model.Categories = selectlist;
            return View(model);
        }
        
        public ActionResult PostDetails(int id)
        {
            PostDTO model = new PostDTO();
            model = bll.GetPostWithID(id);
            return View(model);
        }
    }
}