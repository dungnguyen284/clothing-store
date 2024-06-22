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
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Account GetAccountByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email);
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public Account GetAccountByPhoneNumber(string phoneNumber)
        {
            return _context.Accounts.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        }

        public Account GetAccountByUsername(string username)
        {
            return _context.Accounts.FirstOrDefault(a => a.UserName == username);
        }

        public void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
        }
    }
}
