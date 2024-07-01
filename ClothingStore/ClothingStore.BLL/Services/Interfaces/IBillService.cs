using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface IBillService
    {
        Task<ApiResponse<List<Bill>>> GetAllBillsAsync();
        Task<ApiResponse<Bill>> GetBillsByIdAsync(int id);
        Task<ApiResponse<Bill>> AddBillAsync(Bill bill);
        Task<ApiResponse<Bill>> UpdateBillAsync(Bill bill);
        Task<ApiResponse<List<Bill>>> GetBillBetween(DateTime date1, DateTime date2);
        Task<ApiResponse<List<Bill>>> GetBillByDate(DateTime date);
    }
}


