using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.BL.DTO.User;
using Ecommerse.BL.Services.Interfaces;
using Ecommerse.Core.Entities;
using Ecommerse.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerse.BL.Services.Implements
{
    public class AuthService(UserManager<User> _userManager, SignInManager<User> _signinManger, RoleManager<IdentityRole> _role, IConfiguration _configuration) : IAuthService
    {
        public async Task<IEnumerable<UserGetDTO>> GetUsersAsync()
        {
            var users = await _userManager.Users
             .Select(user => new UserGetDTO
             {
                 Id = user.Id,
                 Fullname = user.FullName,

             })
             .ToListAsync();

            return users;
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            // 1. Şifrə təkrarı
            if (dto.Password != dto.RePassword)
                throw new Exception("Şifrələr eyni deyil!");

            // 2. User var?
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                throw new Exception("Bu email artıq istifadə olunub!");

            // 3. User Yarat
            var user = new User
            {
                Email = dto.Email,
                UserName = dto.Email,
                FullName = dto.FullName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                // Identity xətalarını birləşdirib atırıq
                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMsg);
            }

            // 4. Rol ver (Default: Member)
            await _userManager.AddToRoleAsync(user, "User");
        }

        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);

            // Yoxlama
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                throw new Exception("Email və ya şifrə səhvdir!");

            // Token yarat və sadəcə string kimi qaytar
            return await GenerateJwtToken(user);
        }
        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task Role()
        {
            foreach (var item in Enum.GetValues(typeof(UserRole)))
            {

                string roleName = item.ToString();
                if (!await _role.RoleExistsAsync(roleName))
                {
                    await _role.CreateAsync(new IdentityRole(roleName));
                }
            }

        }
    }
}
