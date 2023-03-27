using System.Collections.Generic;
using System.Web.Mvc;
using DAL;

namespace BLL
{
    public class CategoryBLL
    {
        public static IEnumerable<SelectListItem> GetCategoriesForDropdown()
        {
            return CategoryDAO.GetCategoriesForDropdown();
        }
    }
}