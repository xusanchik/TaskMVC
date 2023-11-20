using System.ComponentModel.DataAnnotations;

namespace TaskMVC.Dto_s
{
    public class ProductDto
    {
        public string Title { get; set; }
        public double Quantiy { get; set; }
        public double Price { get; set; }
    }
}
