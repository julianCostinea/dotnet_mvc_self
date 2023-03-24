using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class PostDAO
    {
        public List<PostDTO> GetPosts()
        {
            List<PostDTO> dtolist = new List<PostDTO>();
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                List<Post> list = db.Posts.Where(x=>x.isDeleted==0).ToList();
                foreach (var item in list)
                {
                    PostDTO dto = new PostDTO();
                    dto.ID = item.ID;
                    dto.Title = item.Title;
                    dto.ShortContent = item.ShortContent;
                    dto.SeoLink = item.SeoLink;
                    dtolist.Add(dto);
                }
            }
            return dtolist;
        }

        public int AddPost(Post post)
        {
            try
            {
                using (POSTDATASELFEntities db = new POSTDATASELFEntities())
                {
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return post.ID;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeletePost(int id, SessionDTO session)
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                Post post = db.Posts.FirstOrDefault(x => x.ID == id);
                post.isDeleted = 1;
                post.DeletedDate = DateTime.Now;
                post.LastUpdateUserID = session.UserID;
                post.LastUpdateDate = DateTime.Now;
                db.SaveChanges();
            }
        }

        public PostDTO GetPostWithID(int id)
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                Post post = db.Posts.FirstOrDefault(x => x.ID == id);
                PostDTO dto = new PostDTO();
                dto.ID = post.ID;
                dto.Title = post.Title;
                dto.ShortContent = post.ShortContent;
                dto.SeoLink = post.SeoLink;
                return dto;
            }
        }

        public void UpdatePost(PostDTO model, SessionDTO session)
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                Post post = db.Posts.FirstOrDefault(x => x.ID == model.ID);
                post.Title = model.Title;
                post.ShortContent = model.ShortContent;
                post.SeoLink = model.SeoLink;
                post.LastUpdateUserID = session.UserID;
                post.LastUpdateDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}