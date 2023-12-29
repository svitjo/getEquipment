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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext _dbContext;

        public AppointmentRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<Appointment> GetAllAppointmentsByAdmin(Guid adminID)
        {
            Appointment appoitments = await _dbContext.Appointments.SingleOrDefaultAsync(c => c.AdminId == adminID);
            return appoitments;
        }
    }
}
