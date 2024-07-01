using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStore.DAL.Models
{
    public class BillDetail
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("BillId")]
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}