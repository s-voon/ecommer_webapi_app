using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Entities
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceDetailId { get; set; }

        [ForeignKey("InvoiceId")]
        public int InvoiceId{ get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
