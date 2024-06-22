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
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByPhoneNumber(string phoneNumber);
        public List<Customer> GetCustomersByName(string name);
    }
}
