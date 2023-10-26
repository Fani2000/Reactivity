using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public class AppException
    {
        public AppException(int statusCode, string message, string details = null)
        {
            this.statusCode = statusCode;
            Message = message;
            this.details = details;
        }

        public int statusCode { get; set; }
        public string Message { get; set; }
        public string details { get; set; }
    }
}