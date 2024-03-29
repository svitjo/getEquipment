﻿using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid userID);
        Task CancelReservedAppointmentPenalty(Guid userID, int penalty);
    }
}
