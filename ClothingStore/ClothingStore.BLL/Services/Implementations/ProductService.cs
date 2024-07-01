using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<bool>> AddProductAsync(Product product)
        {
            ApiResponse<bool> response = new();
            var productExist = await _productRepository.GetProductByNameAsync(product.Name);
            if (productExist != null)
            {
                response.Data = false;
                response.Message = "Product already exist";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            await _productRepository.AddProductAsync(product);
            response.Data = true;
            response.Message = "Product added successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;

        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(Product product)
        {
            var response = new ApiResponse<bool>();
            var productExist = await _productRepository.GetProductByIdAsync(product.Id);
            if (productExist == null)
            {
                response.Data = false;
                response.Message = "Product not found";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            productExist.IsDeleted = true;
            await _productRepository.UpdateProductAsync(productExist);
            response.Data = true;
            response.Message = "Product deleted successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;

        }

        public async Task<ApiResponse<List<Product>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return new ApiResponse<List<Product>> {
                Data = products, 
                Message = "Products fetched successfully",
                StatusCode = HttpStatusCode.OK
            };

        }

        public async Task<ApiResponse<List<Product>>> GetProductByCategoryAsync(int id)
        { 
            var products = await _productRepository.GetProductsByCategoryAsync(id);
            return new ApiResponse<List<Product>>
            {
                Data = products, 
                Message = "Products fetched successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<Product>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id); 
            if (product == null)
            {
                return new ApiResponse<Product>
                {
                    Data = null,
                    Message = "Product not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            return new ApiResponse<Product>
            {
                Data = product,
                Message = "Product fetched successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<List<Product>>> GetProductByNameAsync(string name)
        {
            var products = await _productRepository.GetProductByNameAsync(name);
            return new ApiResponse<List<Product>>
            {
                Data = products,
                Message = "Products fetched successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<bool>> UpdateProductAsync(Product product)
        {
            var response = new ApiResponse<bool>();
            var productExist = await _productRepository.GetProductByIdAsync(product.Id);
            if (productExist == null)
            {
                response.Data = false;
                response.Message = "Product not found";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            await _productRepository.UpdateProductAsync(product);
            response.Data = true;
            response.Message = "Product updated successfully";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
