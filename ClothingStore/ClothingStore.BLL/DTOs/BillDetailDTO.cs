using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.DTOs
{
    public class BillDetailDTO
    {
        public int Id { get; set; } 
        public int BillId { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
    }
}
