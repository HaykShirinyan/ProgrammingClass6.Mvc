using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class ProductSizeViewModel
    {
        public ProductSize ProductSize { get; set; }
        public List<Size> Sizes { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
