using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.DTOs;
using ClothingStore.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        public Task<ApiResponse<bool>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
