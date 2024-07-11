using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.WPF.DTOs
{
    public class BillDTO
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
    }
}
