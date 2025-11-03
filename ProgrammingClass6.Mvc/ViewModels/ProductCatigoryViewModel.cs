using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class ProductCategoryViewModel
    {
        public ProductCategory ProductCategory { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
