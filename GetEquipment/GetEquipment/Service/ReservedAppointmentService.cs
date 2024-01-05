using GetEquipment.Interface;
using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Service
{
    public class ReservedAppointmentService : IReservedAppointmentService
    {
        private readonly IReservedAppointmentRepository _reservedAppointmentRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IReservedEquipmentRepository _reservedEquipmentRepository;

        public ReservedAppointmentService(IReservedAppointmentRepository reservedAppointmentRepository, IAppointmentRepository appointmentRepository, IReservedEquipmentRepository reservedEquipmentRepository)
        {
            _reservedAppointmentRepository = reservedAppointmentRepository ?? throw new ArgumentNullException(nameof(reservedAppointmentRepository));
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
            _reservedEquipmentRepository = reservedEquipmentRepository ?? throw new ArgumentNullException(nameof(reservedEquipmentRepository));
        }

        public async Task ReserveAppointment(Guid appointmentId, Guid userId, IEnumerable<Guid> equipmentIds)
        {
            await _appointmentRepository.BookAppointment(appointmentId);

            var reservedAppointment = new ReservedAppointment
            {
                AppointmentId = appointmentId,
                UserId = userId,
                IsCanceled = false
            };
            await _reservedAppointmentRepository.AddAsync(reservedAppointment);

            foreach (var equipmentId in equipmentIds)
            {
                var reservedEquipment = new ReservedEquipment
                {
                    ReservedAppointmentID = reservedAppointment.ReservationId,
                    EquipmentID = equipmentId
                };

                await _reservedEquipmentRepository.AddAsync(reservedEquipment);
            }
        }
        public async Task CancelAppointment(Guid appointmentId)
        {
            await _appointmentRepository.CancelAppointment(appointmentId);
            await _reservedAppointmentRepository.CancelReservedAppointment(appointmentId);
        }
    }
}