using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace DAL
{
    public class CategoryDAO
    {
        public static IEnumerable<SelectListItem> GetCategoriesForDropdown()
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                IEnumerable<SelectListItem> categories = db.Categories.Where(x => x.isDeleted == false).Select(x =>
                    new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = SqlFunctions.StringConvert((double)x.ID),
                    }).ToList();
                return categories;
            }
        }
    }
}