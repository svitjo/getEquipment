using GetEquipment.Data;
using GetEquipment.Interface;
using GetEquipment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<User> GetAsync(Guid userID)
        {
            User user = await _dbContext.Users.SingleOrDefaultAsync(c => c.UserID == userID);
            return user;
        }
        public async Task CancelReservedAppointmentPenalty(Guid userID, int penalty)
        {
            var user = await GetAsync(userID);
            if (user != null)
            {
                user.Penalty += penalty;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
