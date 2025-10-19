using ProgrammingClass6.Mvc.Models;
using System.Collections.Generic;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class CategoriesViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}