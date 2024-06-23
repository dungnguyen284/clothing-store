using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<bool>> AddProductAsync(Product product);
        Task<ApiResponse<bool>> UpdateProductAsync(Product product);
        Task<ApiResponse<bool>> DeleteProductAsync(Product product);
        Task<ApiResponse<List<Product>>> GetAllProductsAsync();
        Task<ApiResponse<Product>> GetProductByIdAsync(int id);
        Task<ApiResponse<Product>> GetProductByNameAsync(string name);
        Task<ApiResponse<List<Product>>> GetProductByCategoryAsync(int id);
    }
    
}
