using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ApiResponse<Bill>> AddBillAsync(Bill bill)
        {
            var response = new ApiResponse<Bill>();
            var billExist = await _billRepository.GetBillByIdAsync(bill.Id);
            if (billExist != null)
            {
                response.Data = null;
                response.Message = "Bill already exist";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
        }

        public async Task<ApiResponse<List<Bill>>> GetAllBillsAsync()
        {
            var response = new ApiResponse<List<Bill>>();
            var bills = await _billRepository.GetAllBillsAsync();
            response.Data = bills;
            response.Message = "Bills fetched successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;


        }

        public async Task<ApiResponse<List<Bill>>> GetBillBetween(DateTime date1, DateTime date2)
        {
            var response = new ApiResponse<List<Bill>>();
            var bills = await _billRepository.GetBillBetweenAsync(date1, date2);
            response.Data = bills;
            response.Message = "Bills fetched successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<List<Bill>>> GetBillByDate(DateTime date)
        {
            var response = new ApiResponse<List<Bill>>();
            var bills = await _billRepository.GetBillsByDateAsync(date);
            response.Data = bills;
            response.Message = "Bills fetched successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<Bill>> GetBillsByIdAsync(int id)
        {
            var response = new ApiResponse<Bill>();
            var bill = await _billRepository.GetBillByIdAsync(id);
            if (bill == null)
            {
                response.Data = null;
                response.Message = "Bill not found";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            response.Data = bill;
            response.Message = "Bill fetched successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<Bill>> UpdateBillAsync(Bill bill)
        {
            var response = new ApiResponse<Bill>();
            var billExisted = _billRepository.GetBillByIdAsync(bill.Id);
            if (billExisted == null)
            {
                response.Data = null;
                response.Message = "Bill not found";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            await _billRepository.UpdateBillAsync(bill);
            response.Data = bill;
            response.Message = "Bill updated successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
