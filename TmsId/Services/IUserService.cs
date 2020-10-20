using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TmsId.Shared;

namespace TmsId.Api.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }

    public class UserService : IUserService
    {

        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    message = "There is no user by that name",
                    IsSuccess = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    message = "Invalid User",
                    IsSuccess = false
                };
            }

            //build claim for the token
            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            //get the encryption key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            //generate the token object
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            //Give the string representation of that object
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                message = tokenString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };

        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    message = "Confirm password doesnt match the password",
                    IsSuccess = false
                };
            }

            var identityuser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    message = "User Created Successfully",
                    IsSuccess = true
                };
            }

            return new UserManagerResponse
            {
                message = "User Creation failed!",
                IsSuccess = false
            };
        }
    }


}
