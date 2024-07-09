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
    public class CategoryService
    {
        public async Task<List<Category>> GetCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAllCategoriesApi);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<ApiResponse<List<Category>>>(result);
                    if (categories.IsSuccess)
                    {
                        return categories.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + categories.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task<Category> GetCategory(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getCategoryByIdApi + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Category>>(result);

                    if (apiResponse.IsSuccess)
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + apiResponse.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
    }
}
