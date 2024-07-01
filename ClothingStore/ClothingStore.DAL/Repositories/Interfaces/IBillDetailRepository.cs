using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IBillDetailRepository
    {
        Task AddBillDetailAsync(BillDetail billDetail);
        Task UpdateBillDetailAsync(BillDetail billDetail);
        Task DeleteBillDetailAsync(BillDetail billDetail);
        Task<List<BillDetail>> GetAllBillDetailsAsync();
        Task<BillDetail> GetBillDetailByIdAsync(int id);
        Task<List<BillDetail>> GetBillDetailsByBillIdAsync(int billId);

    }
}
