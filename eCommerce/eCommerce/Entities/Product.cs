using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        [Required]
        public string productName { get; set; } = string.Empty;

        public double price { get; set; }

        public string? productDescription { get; set; }




    }
}
