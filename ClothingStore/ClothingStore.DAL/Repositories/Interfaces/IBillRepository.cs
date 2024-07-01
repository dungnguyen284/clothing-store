using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IBillRepository
    {
        public Task AddBillAsync(Bill bill);
        public Task UpdateBillAsync(Bill bill);
        public Task<Bill> GetBillByIdAsync(int id);
        public Task<List<Bill>> GetBillsByCustomerIdAsync(int customerId);
        public Task<List<Bill>> GetAllBillsAsync();
        public Task<List<Bill>> GetBillsByDateAsync(DateTime date);
        public Task<List<Bill>> GetBillBetweenAsync(DateTime date1, DateTime date2);
    }
}
