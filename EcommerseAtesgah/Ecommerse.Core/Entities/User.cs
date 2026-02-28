using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ecommerse.Core.Entities
{
    public class User :IdentityUser
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsBlocked()
        {
            return IsDeleted && DeletedDate.HasValue && DateTime.UtcNow < DeletedDate.Value.AddYears(1);
        }
        public string FullName { get; set; }
    }
}
