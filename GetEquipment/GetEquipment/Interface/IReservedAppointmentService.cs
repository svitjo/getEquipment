using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IReservedAppointmentService
    {
        Task ReserveAppointment(Guid appointmentId, Guid userId, IEnumerable<Guid> equipmentIds);
        Task CancelAppointment(Guid appointmentId);
    }
}
