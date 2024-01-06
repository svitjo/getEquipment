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
        private readonly IUserRepository _userRepository;

        public ReservedAppointmentService(IReservedAppointmentRepository reservedAppointmentRepository, IAppointmentRepository appointmentRepository, IReservedEquipmentRepository reservedEquipmentRepository, IUserRepository userRepository)
        {
            _reservedAppointmentRepository = reservedAppointmentRepository ?? throw new ArgumentNullException(nameof(reservedAppointmentRepository));
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
            _reservedEquipmentRepository = reservedEquipmentRepository ?? throw new ArgumentNullException(nameof(reservedEquipmentRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task ReserveAppointment(Guid appointmentId, Guid userId, IEnumerable<Guid> equipmentIds)
        {
            if (await _reservedAppointmentRepository.HasUserReservedAppointment(userId, appointmentId))
            {
                throw new InvalidOperationException("User has already reserved and canceled this appointment.");
            }
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
            var appointment = await _appointmentRepository.GetAsync(appointmentId);
            var user = await _reservedAppointmentRepository.GetUserByAppointmentAsync(appointmentId);

            TimeSpan timeDifference = appointment.DateAndTimeOfAppointment - DateTime.UtcNow;
            int penaltyPoints = (timeDifference.TotalHours < 24) ? 2 : 1;

            await _appointmentRepository.CancelAppointment(appointmentId);
            await _userRepository.CancelReservedAppointmentPenalty(user.UserID, penaltyPoints);
            await _reservedAppointmentRepository.CancelReservedAppointment(appointmentId);
        }
    }
}