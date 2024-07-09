using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.WPF.Services
{
    public class ProductService
    {
        
        public async Task<List<Product>> GetAllProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAllProductsApi);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<ApiResponse<List<Product>>>(result);
                    if (products.IsSuccess)
                    {
                        return products.Data;
                    }
                    else
                    {
                        throw new Exception("API failed: " + products.Message);
                    }
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API call failed with status: {response.StatusCode} - {response.ReasonPhrase}. Response Content: {responseContent}");
                }
            }
        }
    
        public async Task<Product> GetProductById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getProductByIdApi + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ApiResponse<Product>>(result);
                    if (product.IsSuccess)
                    {
                        return product.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + product.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task<List<Product>> GetProductByCategoryId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getProductByCategoryIdApi + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ApiResponse<List<Product>>>(result);
                    if (product.IsSuccess)
                    {
                        return product.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + product.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task<List<Product>> GetProductByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getProductByNameApi + name);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<ApiResponse<List<Product>>>(result);
                    if (products.IsSuccess)
                    {
                        return products.Data;
                    }
                    else
                    {
                        throw new Exception("API failed: " + products.Message);
                    }
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API call failed with status: {response.StatusCode} - {response.ReasonPhrase}. Response Content: {responseContent}");
                }
            }
        }
        public async Task<bool> DeleteProductById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(Api.getProductByIdApi + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ApiResponse<bool>>(result);
                    if (product.IsSuccess)
                    {
                        return product.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + product.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task AddProduct(Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the product object to JSON
                var jsonContent = JsonConvert.SerializeObject(product);

                // Create StringContent with the JSON content and set the content type to application/json
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7295/api/products", content);
               
            }
        }
        public async Task UpdateProduct(int id, Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the product object to JSON
                var jsonContent = JsonConvert.SerializeObject(product);

                // Create StringContent with the JSON content and set the content type to application/json
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("https://localhost:7295/api/products/" + id, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("API call failed: " + response);
                }
            }
        }
    }
}
