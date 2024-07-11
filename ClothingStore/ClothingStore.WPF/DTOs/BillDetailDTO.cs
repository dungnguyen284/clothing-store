using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.WPF.DTOs
{
    public class BillDetailDTO
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
