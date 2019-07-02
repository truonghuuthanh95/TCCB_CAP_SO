using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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