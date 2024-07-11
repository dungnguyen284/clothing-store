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
    public class BillService
    {
        public async Task<List<Bill>> GetBills()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAllBillsApi);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var bills = JsonConvert.DeserializeObject<ApiResponse<List<Bill>>>(result);
                    if (bills.IsSuccess)
                    {
                        return bills.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + bills.Message);
                    }
                }
                else
                {
                    throw new Exception("API call failed: " + response.ReasonPhrase);
                }
            }
        }
        public async Task<Bill> GetBillById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Api.getAllBillsApi + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var bills = JsonConvert.DeserializeObject<ApiResponse<Bill>>(result);
                    if (bills.IsSuccess)
                    {
                        return bills.Data;
                    }
                    else
                    {
                        throw new Exception("API call failed: " + bills.Message);
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
