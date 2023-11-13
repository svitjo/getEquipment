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
            if (await UserExists(user.email))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            user.userID = new Guid();
            user.role = Role.EMPLOYEE;
            user.penalty = 0;
            context.Add(user);
            await context.SaveChangesAsync();

            return response;
        }
        public async Task<bool> UserExists(string email)
        {
            return await context.Users.AnyAsync(u => u.email.ToLower().Equals(email.ToLower()));
        }
    }
}