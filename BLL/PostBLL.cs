using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class PostBLL
    {
        PostDAO dao = new PostDAO();

        public List<PostDTO> GetPostList()
        {
            return dao.GetPosts();
        }

        public bool AddPost(PostDTO model, SessionDTO session)
        {
            Post post = new Post();
            post.Title = model.Title;
            post.ShortContent = model.ShortContent;
            post.PostContent = "model.PostContent";
            post.Slider = false;
            post.Area1 = false;
            post.Area2 = false;
            post.Area3 = false;
            post.Notification = false;
            post.CategoryID = 1;
            post.SeoLink = model.SeoLink;
            post.LanguageName = "english";
            post.AddDate = DateTime.Now;
            post.AddUserID = session.UserID;
            post.LastUpdateUserID = session.UserID;
            post.LastUpdateDate = DateTime.Now;
            int postId = dao.AddPost(post);
            LogDAO.AddLog(1, "Post", postId, session);
            return true;
        }

        public void DeletePost(int id, SessionDTO session)
        {
            dao.DeletePost(id, session);
        }
    }
}