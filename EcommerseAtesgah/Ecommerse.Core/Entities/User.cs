using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        

    }
}
