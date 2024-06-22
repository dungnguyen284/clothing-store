using ClothingStore.DAL.Contexts;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Implementations
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDBContext _context;
        public BillRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
        }

        public List<Bill> GetAllBills()
        {
            return _context.Bills.ToList();
        }

        public List<Bill> GetBillBetween(DateTime date1, DateTime date2)
        {
            return _context.Bills.Where(b => b.Date >= date1 && b.Date <= date2).ToList();
        }

        public Bill GetBillById(int id)
        {
            return _context.Bills.FirstOrDefault(b => b.Id == id);
        }

        public List<Bill> GetBillsByCustomerId(int customerId)
        {
            return _context.Bills.Where(b => b.CustomerId == customerId).ToList();
        }

        public List<Bill> GetBillsByDate(DateTime date)
        {
            return _context.Bills.Where(b => b.Date == date).ToList();
        }

        public void UpdateBill(Bill bill)
        {
            _context.Bills.Update(bill);
        }
    }
}
