using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsByAdmin(Guid adminID);
        Task<Appointment> GetAsync(Guid appointmentID);
        Task<IEnumerable<Appointment>> GetNonReservedAppointments();
        Task<IEnumerable<Appointment>> GetAllAppointmentsByCompany(Guid workcalendarID);
    }
}
