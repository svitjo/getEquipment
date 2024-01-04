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

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByAdmin(Guid adminID)
        {
            var appoitments = await _dbContext.Appointments.Where(c => c.AdminId == adminID).ToListAsync();
            return appoitments;
        }

        public async Task<Appointment> GetAsync(Guid appointmentID)
        {
            Appointment appointment = await _dbContext.Appointments.SingleOrDefaultAsync(c => c.AppointmentID == appointmentID);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetNonReservedAppointments()
        {
            var nonReservedAppointments = await _dbContext.Appointments.Where(a => !a.IsReserved).ToListAsync();
            return nonReservedAppointments;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByCompany(Guid workcalendarID)
        {
            var appoitments = await _dbContext.Appointments.Where(c => c.WorkCalendarID == workcalendarID).ToListAsync();
            return appoitments;
        }
    }
}
