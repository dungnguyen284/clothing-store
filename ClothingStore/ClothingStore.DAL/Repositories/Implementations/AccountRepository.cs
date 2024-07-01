using ClothingStore.DAL.Contexts;
using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return  await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
