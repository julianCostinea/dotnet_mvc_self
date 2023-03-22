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
                foreach (var item in db.Posts)
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
    }
}