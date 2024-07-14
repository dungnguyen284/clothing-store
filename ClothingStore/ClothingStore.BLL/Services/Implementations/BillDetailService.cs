using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Implementations;
using ClothingStore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class BillDetailService : IBillDetailService
    {
        private readonly IBillDetailRepository _billDetailRepository;
        public BillDetailService(IBillDetailRepository billDetailRepository)
        {
            _billDetailRepository = billDetailRepository;
        }

        public async Task<ApiResponse<bool>> AddBillDetail(BillDetail billDetail)
        {
            ApiResponse<bool> response = new();

            await _billDetailRepository.AddBillDetailAsync(billDetail);
            response.Data = true;
            response.Message = "Bill Detail added successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<List<BillDetail>>> GetBillDetailsOfBill(int billId)
        {
            var response = new ApiResponse<List<BillDetail>>();
            var billDetails = await _billDetailRepository.GetBillDetailsByBillIdAsync(billId);
            
            response.Data = billDetails;
            response.StatusCode = HttpStatusCode.OK;
            return response;

        }
    }
}
