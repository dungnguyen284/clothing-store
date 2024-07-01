using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse<bool>> AddCustomerAsync(Customer customer)
        {
            var response = new ApiResponse<bool>();
            if ((await _customerRepository.GetCustomerByIdAsync(customer.Id)) != null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Existed ID";
                response.Data = false;
                return response;
            }
            if ((await _customerRepository.GetCustomerByPhoneNumberAsync(customer.Phone)) != null)
            {
                response.StatusCode= HttpStatusCode.BadRequest;
                response.Data= false;
                response.Message = "This Phone number has been registered";
                return response;
            }
            await _customerRepository.AddCustomerAsync(customer);
            response.StatusCode = HttpStatusCode.OK;
            response.Data = true;
            response.Message = "Added customer";
            return response;

        }

        public async Task<ApiResponse<List<Customer>>> GetAllCustomersAsync()
        {
            var response = new ApiResponse<List<Customer>>();
            var customers = await _customerRepository.GetAllCustomersAsync();
            response.StatusCode = HttpStatusCode.OK;
            response.Data = customers;
            response.Message = "successfully";
            return response;
        }

        public async Task<ApiResponse<Customer>> GetCustomerByIdAsync(int id)
        {
            var response = new ApiResponse<Customer>();

            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                response.Data = null;
                response.Message = "";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Data = customer;
            response.Message = "Successfully";
        }

        public async Task<ApiResponse<List<Customer>>> GetCustomerByNameAsync(string name)
        {
            var response = new ApiResponse<List<Customer>>();
            var customers = await _customerRepository.GetCustomersByNameAsync(name);
            response.StatusCode = HttpStatusCode.OK;
            response.Data = customers;
            response.Message = "successfully";
            return response;
        }

        public async Task<ApiResponse<Customer>> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            var response = new ApiResponse<Customer>();
            var customer = await _customerRepository.GetCustomerByPhoneNumberAsync(phoneNumber);
            if (customer == null)
            {
                response.Data = null;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "No customer found";
                return response;
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Data = customer;
            response.Message = "successfully";
            return response;
        }

        public Task<ApiResponse<bool>> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}


