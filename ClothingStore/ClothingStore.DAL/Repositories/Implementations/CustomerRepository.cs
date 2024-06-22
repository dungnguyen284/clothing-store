using ClothingStore.DAL.Contexts;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _context.Customers.FirstOrDefault(c => c.Phone == phoneNumber);
        }

        public List<Customer> GetCustomersByName(string name)
        {
            return _context.Customers.Where(c => c.UserName.Contains(name)).ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
