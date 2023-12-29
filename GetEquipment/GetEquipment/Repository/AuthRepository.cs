using AutoMapper;
using Microsoft.AspNetCore.Identity;
using GetEquipment.Data;
using GetEquipment.Interface;
using GetEquipment.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GetEquipment.Model.Enum;
using GetEquipment.Service;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GetEquipment.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthRepository(DataContext context, IConfiguration configuration, IMapper mapper)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.context = context;
        }
        public async Task<UniversalResponse<int>> Register(User user)
        {
            UniversalResponse<int> response = new UniversalResponse<int>();
            if (await UserExists(user.Email))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            user.UserID = new Guid();
            user.Role = Role.EMPLOYEE;
            user.Penalty = 0;
            user.IsVerified = false;

            Guid verificationToken = user.UserID;

            context.Add(user);
            await context.SaveChangesAsync();

            //await SendVerificationEmail(user.email, verificationToken);

            return response;
        }

        public async Task<UniversalResponse<string>> Login(string email, string password)
        {
            var response = new UniversalResponse<string>();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (password != user.Password)
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = BuildToken(user);
            }

            return response;
        }

        public string BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer: "test", audience: "test", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<User> getUserById(Guid id)
        {
            User book = await context.Users.SingleOrDefaultAsync(b => b.UserID == id);
            return book;
        }

        /*
        public async Task<UniversalResponse<int>> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            UniversalResponse<int> response = new UniversalResponse<int>();
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Email confirmed successfully!";
                return response;
            } else 
            {             
                response.Success = true;
                response.Message = "Email confirmed successfully!";
                return response;
            };
        }
        */
        public async Task<bool> UserExists(string email)
        {
            return await context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        }
    }
}