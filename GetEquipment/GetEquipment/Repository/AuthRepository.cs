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

namespace GetEquipment.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;

        public AuthRepository(DataContext context, IConfiguration configuration, IMapper mapper)
        {
            this.mapper = mapper;
            this._configuration = configuration;
            this.context = context;
        }
        public async Task<UniversalResponse<int>> Register(User user)
        {
            UniversalResponse<int> response = new UniversalResponse<int>();
            if (await UserExists(user.email))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            user.userID = new Guid();
            user.role = Role.EMPLOYEE;
            user.penalty = 0;
            user.isVerified = false;

            Guid verificationToken = user.userID;

            context.Add(user);
            await context.SaveChangesAsync();

            //await SendVerificationEmail(user.email, verificationToken);

            return response;
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
            return await context.Users.AnyAsync(u => u.email.ToLower().Equals(email.ToLower()));
        }
    }
}