using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<Category>> CreateCategoryAsync(Category category)
        {
            var response = new ApiResponse<Category>();
            var categoryExist = _categoryRepository.GetCategoryByNameAsync(category.Name);
            if (categoryExist != null)
            {
                response.Data = null;
                response.Message = "Category already exist";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            await _categoryRepository.AddCategoryAsync(category);
            response.Data = category;
            response.Message = "Category added successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<bool>> DeleteCategory(int id)
        {
            var response = new ApiResponse<bool>();
            var categoryExist = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryExist == null)
            {
                response.Data = false;
                response.Message = "Category not found";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            var products = await _productRepository.GetProductsByCategoryAsync(id);
            if (products.Count > 0)
            {
                response.Data = false;
                response.Message = "Category has products";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            await _categoryRepository.DeleteCategoryAsync(categoryExist);
            response.Data = true;
            response.Message = "Category deleted successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<List<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var response = new ApiResponse<List<Category>>();
            response.Data = categories;
            response.Message = "Categories fetched successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public async Task<ApiResponse<Category>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            var response = new ApiResponse<Category>();
            if (category == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Data = null;
                response.Message = "Not found";
                return response;
            }
            response.Message = "Successfully";
            response.StatusCode = HttpStatusCode.OK;
            response.Data = category;
            return response;
        }

        public async Task<ApiResponse<Category>> UpdateCategoryAsync(Category category)
        {
            var categoryExist = await _categoryRepository.GetCategoryByIdAsync(category.Id);
            var response = new ApiResponse<Category>();
            if(categoryExist == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Data = null;
                response.Message = "category not found";
                return response;
            }
            await _categoryRepository.UpdateCategoryAsync(category);
            response.Message = "updated successfully";
            response.StatusCode = HttpStatusCode.OK;
            response.Data = category;
            return response;

        }
    }
}
