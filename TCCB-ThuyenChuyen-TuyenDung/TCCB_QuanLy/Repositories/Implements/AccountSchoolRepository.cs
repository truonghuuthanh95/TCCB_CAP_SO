using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class AccountSchoolRepository : IAccountSchoolRepository
    {
        TCCBDB _db;

        public AccountSchoolRepository(TCCBDB db)
        {
            _db = db;
        }

        public AccountSchool GetAccountSchoolById(int id)
        {
            AccountSchool accountSchool = _db.AccountSchools.Where(s => s.Id == id).SingleOrDefault();
            return accountSchool;
        }

        public List<AccountSchool> GetAccountSchools()
        {
            var accountSchools = _db.AccountSchools.OrderBy(s => s.SchoolName).ToList();
            return accountSchools;
        }
    }
}