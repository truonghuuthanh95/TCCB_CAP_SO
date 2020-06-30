using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class SSOSessionReturn
    {
        public string SchoolId { get; set; }
        public string AccountType { get; set; }

        public SSOSessionReturn(string schoolId, string accountType)
        {
            SchoolId = schoolId;
            AccountType = accountType;
        }
    }
}