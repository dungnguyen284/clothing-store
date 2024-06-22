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
        public void UpdateAccount(Account account);
        public Account GetAccountById(int id);
        public Account GetAccountByUsername(string username);
        public Account GetAccountByEmail(string email);
        public Account GetAccountByPhoneNumber(string phoneNumber);
    }
}
