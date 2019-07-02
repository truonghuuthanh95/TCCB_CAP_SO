using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Utils
{
    public static class CheckValidCode
    {
        public static bool IsValidCodeThuyenChuyen(string code)
        {
            string tienTo = code.Substring(0, 2);
            string id = code.Substring(2);
            if (String.Compare(tienTo, "TC", true) < 0)
            {
                return false;
            }
            int n;
            bool isNumeric = int.TryParse(id, out n);
            if (isNumeric == false)
            {
                return false;
            }
            return false;
        }
    }
}