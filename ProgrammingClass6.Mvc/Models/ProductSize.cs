using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class ProductSize
    {
        public int ProductId { set; get; }

        public Product Product { set; get; }

        public int SizeId { set; get; }

        public Size Size { set; get; }

    }
}