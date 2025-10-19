using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class ProductTypeViewModel
    {
        public ProductType ProductType { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}
