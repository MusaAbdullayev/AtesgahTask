using AutoMapper;
using Ecommerse.BL.DTO.User;
using Ecommerse.BL.ExternalServices.Abstractions;
using Ecommerse.BL.Service.Interface;
using Ecommerse.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Service.Implementation
{
    public class AuthService(IJwtTokenHandler _tokenHandler, UserManager<User> _userManager, SignInManager<User> _signInManager ,IMapper _mapper) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                throw new Exception("Login request cannot be null.");
            User? user = null;

            if (loginDTO.UsernameOrEmail.Contains("@"))
                user = await _userManager.FindByEmailAsync(loginDTO.UsernameOrEmail);
            else
                user = await _userManager.FindByNameAsync(loginDTO.UsernameOrEmail);

            if (user == null)
                throw new Exception("User not found.");

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, loginDTO.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    throw new Exception($"User is locked out until {user.LockoutEnd!.Value:yyyy-MM-dd HH:mm}");
                }

                if (result.IsNotAllowed)
                {
                    throw new Exception("Username or password is incorrect.");
                }

                throw new Exception("Login failed");
            }


            return await _tokenHandler.CreateToken(user, 36);

        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (existingUser != null)
            {
                throw new Exception("A user with this email already exists.");
            }

            User user = _mapper.Map<User>(registerDTO);

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed.");
            }

            

        }
    }
}
