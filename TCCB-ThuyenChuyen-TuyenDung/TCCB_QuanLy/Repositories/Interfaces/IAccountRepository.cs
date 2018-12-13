using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAccounts();
        Account GetAccountByUsernameAndPassword(string username, string password);
    }
}