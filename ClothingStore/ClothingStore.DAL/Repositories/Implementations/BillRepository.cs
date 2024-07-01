using ClothingStore.DAL.Contexts;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddBillAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<List<Bill>> GetBillBetweenAsync(DateTime date1, DateTime date2)
        {
            return await _context.Bills.Where(b => b.Date >= date1 && b.Date <= date2).ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int id)
        {
            return await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Bill>> GetBillsByCustomerIdAsync(int customerId)
        {
            return await _context.Bills.Where(b => b.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Bill>> GetBillsByDateAsync(DateTime date)
        {
            return await _context.Bills.Where(b => b.Date == date).ToListAsync();
        }

        public async Task UpdateBillAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
        }
    }
}
