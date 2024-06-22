using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IBillRepository
    {
        public void AddBill(Bill bill);
        public void UpdateBill(Bill bill);
        public Bill GetBillById(int id);
        public List<Bill> GetBillsByCustomerId(int customerId);
        public List<Bill> GetAllBills();
        public List<Bill> GetBillsByDate(DateTime date);
        public List<Bill> GetBillBetween(DateTime date1, DateTime date2);
    }
}
