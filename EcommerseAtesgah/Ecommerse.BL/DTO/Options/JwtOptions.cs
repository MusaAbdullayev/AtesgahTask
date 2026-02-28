using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.DTO.Options
{
    
        public class JwtOptions
        {
            public const string Jwt = "JwtOptions";
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretKey { get; set; }
        }
    
}
