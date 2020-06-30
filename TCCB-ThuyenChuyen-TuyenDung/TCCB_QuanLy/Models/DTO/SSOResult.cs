using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class SSOResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public SSOResult(int statusCode, string message, object result)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}