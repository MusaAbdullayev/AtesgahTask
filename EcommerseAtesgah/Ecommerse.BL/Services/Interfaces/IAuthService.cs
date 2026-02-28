using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.BL.DTO.User;

namespace Ecommerse.BL.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
        Task<IEnumerable<UserGetDTO>> GetUsersAsync();
        Task Role();
    }
}
