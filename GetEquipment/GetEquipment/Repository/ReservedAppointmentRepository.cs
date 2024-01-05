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
    public class ReservedAppointmentRepository : IReservedAppointmentRepository
    {
        private readonly DataContext _dbContext;

        public ReservedAppointmentRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public async Task<IEnumerable<ReservedAppointment>> GetAllAppointmentsByUser(Guid userID)
        {
            var appoitments = await _dbContext.ReservedAppointments.Where(c => c.UserId == userID).ToListAsync();
            return appoitments;
        }
        public async Task<ReservedAppointment> GetAsync(Guid reservedAppointmentID)
        {
            ReservedAppointment appointment = await _dbContext.ReservedAppointments.SingleOrDefaultAsync(c => c.ReservationId == reservedAppointmentID);
            return appointment;
        }
        public async Task AddAsync(ReservedAppointment reservedAppointment)
        {
            reservedAppointment.ReservationId = new Guid();
            _dbContext.ReservedAppointments.Add(reservedAppointment);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CancelReservedAppointment(Guid appointmentId)
        {
            var appointment = await GetAsync(appointmentId);
            appointment.IsCanceled = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}