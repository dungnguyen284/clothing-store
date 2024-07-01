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
    public class BillDetailRepository : IBillDetailRepository
    {
        private readonly ApplicationDBContext _context;
        public BillDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }   
        public async Task AddBillDetailAsync(BillDetail billDetail)
        {
            await _context.BillDetails.AddAsync(billDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillDetailAsync(BillDetail billDetail)
        {
             _context.BillDetails.Remove(billDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BillDetail>> GetAllBillDetailsAsync()
        {
            return await _context.BillDetails.ToListAsync();
        }

        public async Task<BillDetail> GetBillDetailByIdAsync(int id)
        {
            return await _context.BillDetails.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BillDetail>> GetBillDetailsByBillIdAsync(int billId)
        {
            return await _context.BillDetails.Where(b => b.BillId == billId).ToListAsync();
        }

        public async Task UpdateBillDetailAsync(BillDetail billDetail)
        {
            _context.BillDetails.Update(billDetail);
            _context.SaveChangesAsync();
        }
    }
}
