using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Manufacturer> Manufacturers { get; set; }
    }
}
