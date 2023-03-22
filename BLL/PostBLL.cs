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
    }
}