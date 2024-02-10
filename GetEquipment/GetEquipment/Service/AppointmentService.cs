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
        private readonly IWorkCalendarRepository _workCalendarRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IWorkCalendarRepository workCalendarRepository)
        {
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
            _workCalendarRepository = workCalendarRepository ?? throw new ArgumentNullException(nameof(workCalendarRepository));
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByAdmin(Guid adminID)
        {
            return await _appointmentRepository.GetAllAppointmentsByAdmin(adminID);
        }

        public async Task<Appointment> GetAsync(Guid appointmentID)
        {
            return await _appointmentRepository.GetAsync(appointmentID);
        }

        public async Task<IEnumerable<Appointment>> GetNonReservedAppointments(Guid companyID)
        {
            WorkCalendar workCalendar = await _workCalendarRepository.GetAsync(companyID);
            if (workCalendar != null)
            {
                return await _appointmentRepository.GetNonReservedAppointments(workCalendar.CalendarId);
            }
            else
            {
                return Enumerable.Empty<Appointment>();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByCompany(Guid companyID)
        {
            WorkCalendar workCalendar = await _workCalendarRepository.GetAsync(companyID);
            if (workCalendar != null)
            {
                return await _appointmentRepository.GetAllAppointmentsByCompany(workCalendar.CalendarId);
            }
            else
            {
                return Enumerable.Empty<Appointment>();
            }
        }
    }
}