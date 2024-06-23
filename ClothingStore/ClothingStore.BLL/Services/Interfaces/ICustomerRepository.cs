using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ApiResponse<List<Customer>>> GetAllCustomersAsync();
    }
}
