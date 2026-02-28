using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.Core.Enums;

namespace Ecommerse.BL.Extensions
{
    public static class RoleExtensions
    {
        public static string GetRole(this UserRole role)
        {
            return role switch
            {
                UserRole.Admin => nameof(UserRole.Admin),
                UserRole.User => nameof(UserRole.User),

            };

        }
    }
}
