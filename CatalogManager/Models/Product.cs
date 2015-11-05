using System.ComponentModel.DataAnnotations;
namespace CatalogManager.Models
{
    public class Product
    {
        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        [RegularExpression(@"^[0-9].+$", ErrorMessage = "Must be numeric.")]
        public double Price { set; get; }
    }
}