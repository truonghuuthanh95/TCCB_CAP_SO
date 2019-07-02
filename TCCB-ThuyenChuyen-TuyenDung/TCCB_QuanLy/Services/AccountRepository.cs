using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class AccountRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            using (var _db = new TCCBDB())
            {
                Account account = _db.Accounts.Where(s => s.Username == username.Trim() && s.Password == password.Trim()).SingleOrDefault();
                return account;
            }
            
        }

        public List<Account> GetAccounts()
        {
            using (var _db = new TCCBDB())
            {
                List<Account> accounts = _db.Accounts.ToList();
                return accounts;
            }
            
        }
    }
}