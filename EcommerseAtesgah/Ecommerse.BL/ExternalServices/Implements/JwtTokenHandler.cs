using Ecommerse.BL.DTO.Options;
using Ecommerse.BL.ExternalServices.Abstractions;
using Ecommerse.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.ExternalServices.Implements
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        readonly JwtOptions opt;
        readonly UserManager<User> userManager;
        public JwtTokenHandler(IOptions<JwtOptions> _opt, UserManager<User> _userManager)
        {
            userManager = _userManager;
            opt = _opt.Value;
        }
        public async Task<string> CreateToken(User user, int hours = 36)
        {
            var roles = await userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            List<Claim> claims = [
                new Claim(ClaimTypes.Name, user.FullName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.NameIdentifier, user.Id ?? string.Empty),
           
        ];


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
            SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken secToken = new(
                issuer: opt.Issuer,
                audience: opt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: cred
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }
    }
}
