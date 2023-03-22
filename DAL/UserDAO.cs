using System.Linq;
using DTO;

namespace DAL
{
    public class UserDAO
    {
        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                UserDTO dto = new UserDTO();
                T_User user =
                    db.T_User.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
                if (user != null && user.ID != 0)
                {
                    dto.ID = user.ID;
                    dto.Username = user.Username;
                    dto.Imagepath = user.ImagePath;
                    dto.Name = user.NameSurname;
                    dto.isAdmin = user.isAdmin;
                }

                return dto;
            }
        }
    }
}