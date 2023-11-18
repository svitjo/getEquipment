using AutoMapper;
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

namespace GetEquipment.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
       // private readonly EmailService _emailService;

        public AuthRepository(DataContext context, IConfiguration configuration, IMapper mapper)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.context = context;
            //this._emailService = emailService;
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
        }/*
        private async Task SendVerificationEmail(string userEmail, Guid verificationToken)
        {
            string verificationLink = $"https://localhost:44320/api/v1/auth/verify?token={verificationToken}";
            await _emailService.SendEmailAsync(userEmail, "Account Verification", $"Click the link to verify your account: {verificationLink}");
        }*/
        public async Task<bool> UserExists(string email)
        {
            return await context.Users.AnyAsync(u => u.email.ToLower().Equals(email.ToLower()));
        }
    }
}