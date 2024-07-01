using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddCustomerAsync(Customer customer);
        public Task UpdateCustomerAsync(Customer customer);
        public Task<List<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber);
        public Task<List<Customer>> GetCustomersByNameAsync(string name);
    }
}
