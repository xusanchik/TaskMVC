using System.ComponentModel.DataAnnotations;

namespace TaskMVC.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This product is available")]
        public string Title { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Amout cannot be negative")]
        public double Quantiy { get; set; }
        //[Required(ErrorMessage = "Narxi manfiy bo'lishi mumkin emas")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price cannot be negative")]
        public double Price { get; set; }
        public double TotolPrice { get; set; }
    }
}
