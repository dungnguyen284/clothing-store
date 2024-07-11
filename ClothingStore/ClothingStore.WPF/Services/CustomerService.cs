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
    public class CustomerService
    {
        public async Task<Customer> GetCustomerById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getCustomerByIdApi + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<ApiResponse<Customer>>(result);
                    if (customer.IsSuccess)
                    {
                        return customer.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + customer.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAllCustomersApi);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<ApiResponse<List<Customer>>>(result);
                    if (customer.IsSuccess)
                    {
                        return customer.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + customer.Message);
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
