using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class AccountRepository : IAccountRepository
    {
        TCCBDB _db;

        public AccountRepository(TCCBDB db)
        {
            _db = db;
        }

        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            Account account = _db.Accounts.AsNoTracking().Where(s => s.Username == username.Trim() && s.Password == password.Trim()).SingleOrDefault();
            return account;
        }

        public IQueryable<Account> GetAccounts()
        {
            IQueryable<Account> accounts = _db.Accounts;
            return accounts;
        }
    }
}