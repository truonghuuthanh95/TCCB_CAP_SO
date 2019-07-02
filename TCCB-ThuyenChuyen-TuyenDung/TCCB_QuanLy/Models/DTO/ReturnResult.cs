using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class ReturnResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Results { get; set; }

        public ReturnResult(int statusCode, string message, object results)
        {
            StatusCode = statusCode;
            Message = message;
            Results = results;
        }
    }
}