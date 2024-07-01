using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.DTOs;
using ClothingStore.BLL.Services.Interfaces;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Implementations;
using ClothingStore.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailSender _emailSender;
        public AccountService(IAccountRepository accountRepository, IEmailSender emailSender)
        {
            _accountRepository = accountRepository;
            _emailSender = emailSender;
        }
        public async Task<ApiResponse<bool>> ChangePasswordAsync(ChangePasswordRequest request, int accountId)
        {
            ApiResponse<bool> response = new();
            
            if (request.NewPassword != request.ConfirmPassword)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "New password and confirm password do not match";
                return response;
            }
            var oldPassword = (await _accountRepository.GetAccountByIdAsync(accountId)).Password;
            if(oldPassword != request.OldPassword)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Old password is incorrect";
                return response;
            }
            var account = await _accountRepository.GetAccountByIdAsync(accountId);
            if (account == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Account not found";
                return response;
            }
            account.Password = request.NewPassword;
            await _accountRepository.UpdateAccountAsync(account);
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Password changed successfully";
            response.Data = true;
            return response;

        }
        public async Task<ApiResponse<bool>> LoginAsync(LoginRequest request)
        {
            var response = new ApiResponse<bool>();
            var account = await _accountRepository.GetAccountByUsernameAsync(request.Username);
            if (account == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Account not found";
                return response;
            }
            if (account.Password != request.Password)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password is incorrect";
                return response;
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Login successful";
            response.Data = true;
            return response;
        }
        public async Task<ApiResponse<bool>> ForgotPasswordAsync(string email)
        {
            ApiResponse<bool> response = new();
            var account = await _accountRepository.GetAccountByEmailAsync(email);
            if (account == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Account not found";
                return response;
            }
            string newPassword = GenerateRandomPassword();
            account.Password = newPassword;
            await _accountRepository.UpdateAccountAsync(account);
            // send email to user with password
            await _emailSender.SendEmailAsync(email, "Password Recovery", $"Your new password is {newPassword}");
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Password sent to email";
            response.Data = true;
            return response;
        }
        private string GenerateRandomPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new();
            return new string(Enumerable.Repeat(chars, 8)
                             .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
