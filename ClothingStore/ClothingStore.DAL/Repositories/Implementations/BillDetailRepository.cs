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
    public class BillDetailRepository : IBillDetailRepoository
    {
        private readonly ApplicationDBContext _context;
        public BillDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }   
        public void AddBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Add(billDetail);
        }

        public void DeleteBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Remove(billDetail);
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return _context.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(int id)
        {
            return _context.BillDetails.FirstOrDefault(b => b.Id == id);
        }

        public List<BillDetail> GetBillDetailsByBillId(int billId)
        {
            return _context.BillDetails.Where(b => b.BillId == billId).ToList();
        }

        public void UpdateBillDetail(BillDetail billDetail)
        {
            return _context.BillDetails.Update(billDetail);
        }
    }
}
