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

        public List<Account> GetAccounts()
        {
            List<Account> accounts = _db.Accounts.ToList();
            return accounts;
        }
    }
}