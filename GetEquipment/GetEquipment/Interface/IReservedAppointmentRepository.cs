using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IReservedAppointmentRepository
    {
        Task<IEnumerable<ReservedAppointment>> GetAllAppointmentsByUser(Guid userID);
        Task<ReservedAppointment> GetAsync(Guid reservedAppointmentID);
        Task AddAsync(ReservedAppointment reservedAppointment);
        Task CancelReservedAppointment(Guid reservationID);
    }
}
