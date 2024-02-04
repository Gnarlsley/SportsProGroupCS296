using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Product
    {
        public int ProductID { get; set; }


        //New Code
        [Required(ErrorMessage = "Please enter a product code")]
        public string ProductCode { get; set; } = string.Empty;

        //New Code
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; } = string.Empty;

        //New Code
        [Required(ErrorMessage = "Please enter a yearly price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Yearly price must be greater than $0.00")]

        [Column(TypeName = "decimal(8,2)")]
        public decimal YearlyPrice { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Now;
    }
}
