using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task UpdateAccountAsync(Account account);
        Task<Account> GetAccountByIdAsync(int id);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<Account> GetAccountByEmailAsync(string email);
        Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber);
    }
}
