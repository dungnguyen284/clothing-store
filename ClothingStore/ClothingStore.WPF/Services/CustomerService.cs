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
        public async Task UpdateCustomer(int id, Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the product object to JSONt
                var jsonContent = JsonConvert.SerializeObject(customer);

                // Create StringContent with the JSON content and set the content type to application/json
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("https://localhost:7295/api/customers/" + id, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("API call failed: " + response);
                }
            }
        }
        public async Task AddCustomer(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the product object to JSON
                var jsonContent = JsonConvert.SerializeObject(customer);

                // Create StringContent with the JSON content and set the content type to application/json
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7295/api/customers", content);

            }
        }
    }
}
