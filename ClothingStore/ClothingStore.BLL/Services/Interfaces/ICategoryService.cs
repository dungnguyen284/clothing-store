using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<List<Category>>> GetAllCategoriesAsync();
        Task<ApiResponse<Category>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<Category>> CreateCategoryAsync(Category Category);
        Task<ApiResponse<Category>> UpdateCategoryAsync(Category Category);
        Task<ApiResponse<bool>> DeleteCategory(int id);
    }
}
