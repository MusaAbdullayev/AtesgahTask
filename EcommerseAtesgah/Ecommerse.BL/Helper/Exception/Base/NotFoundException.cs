using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Helper.Exception.Base
{
    internal class NotFoundException : BaseException
    {
        public NotFoundException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
        {
        }
    }
}
