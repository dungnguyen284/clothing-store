using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<List<Customer>>> GetAllCustomersAsync();
        Task<ApiResponse<bool>> AddCustomerAsync(Customer customer);
        Task<ApiResponse<bool>> UpdateCustomerAsync(Customer customer);
        Task<ApiResponse<Customer>> GetCustomerByIdAsync(int id);
        Task<ApiResponse<List<Customer>>> GetCustomerByNameAsync(string name);
        Task<ApiResponse<Customer>> GetCustomerByPhoneNumberAsync(string phoneNumber);

    }
}
