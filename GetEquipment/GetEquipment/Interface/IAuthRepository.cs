﻿using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IAuthRepository
    {
        Task<UniversalResponse<int>> Register(User user);
        Task<UniversalResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        //Task<UniversalResponse<int>> ConfirmEmailAsync(string userId, string token);
    }
}
