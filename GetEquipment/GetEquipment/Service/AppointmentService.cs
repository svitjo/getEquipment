using GetEquipment.Interface;
using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByAdmin(Guid adminID)
        {
            return await _appointmentRepository.GetAllAppointmentsByAdmin(adminID);
        }

        public async Task<Appointment> GetAsync(Guid appointmentID)
        {
            return await _appointmentRepository.GetAsync(appointmentID);
        }

        public async Task<IEnumerable<Appointment>> GetNonReservedAppointments(Guid workcalendarID)
        {
            return await _appointmentRepository.GetNonReservedAppointments(workcalendarID);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByCompany(Guid workcalendarID)
        {
            return await _appointmentRepository.GetAllAppointmentsByCompany(workcalendarID);
        }
    }
}