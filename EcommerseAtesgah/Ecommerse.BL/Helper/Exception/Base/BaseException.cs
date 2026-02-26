using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Helper.Exception.Base
{
    internal class BaseException : System.Exception
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public BaseException(string errorMessage, int statusCode) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
