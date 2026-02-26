using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.BL.Helper.Exception.Base;

namespace Ecommerse.BL.Helper.Exception.Product
{
    internal class ProductException : BaseException
    {
        public ProductException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
        {
        }
    }
}
