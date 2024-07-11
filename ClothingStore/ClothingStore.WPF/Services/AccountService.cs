using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.DTOs;
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
    public class AccountService
    {
        public async Task<Account> GetAccountByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAccountByNameApi + name);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var account = JsonConvert.DeserializeObject<ApiResponse<Account>>(result);
                    if (account.IsSuccess)
                    {
                        return account.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + account.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }

        public async Task ChangePassword(ChangePasswordRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the product object to JSON
                var jsonContent = JsonConvert.SerializeObject(request);

                // Create StringContent with the JSON content and set the content type to application/json
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(Api.changePasswordApi + "1", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("API call failed: " + response);
                }
            }
        }
    }
}
