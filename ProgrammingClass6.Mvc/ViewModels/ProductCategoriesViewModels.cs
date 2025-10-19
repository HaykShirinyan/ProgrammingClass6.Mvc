using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class ProductCategoriesViewModels
    {
        public Product Product { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
