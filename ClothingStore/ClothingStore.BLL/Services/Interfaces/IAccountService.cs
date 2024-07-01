using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse<bool>> ForgotPasswordAsync(string email);
        Task<ApiResponse<bool>> LoginAsync(LoginRequest request);
        Task<ApiResponse<bool>> ChangePasswordAsync(ChangePasswordRequest request, int accountId);
    }
}
