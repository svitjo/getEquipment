using GetEquipment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Controller
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservedAppointmentController : ControllerBase
    {
        private readonly IReservedAppointmentService _reservedAppointmentService;
        private readonly ILogger<ReservedAppointmentController> _logger;
    

        public ReservedAppointmentController(IReservedAppointmentService reservedAppointmentService, ILogger<ReservedAppointmentController> logger)
        {
            _reservedAppointmentService = reservedAppointmentService ?? throw new ArgumentNullException(nameof(reservedAppointmentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("ReserveAppointment")]
        public async Task<IActionResult> ReserveAppointment([FromQuery] Guid appointmentId, [FromQuery] Guid userId, [FromQuery] IEnumerable<Guid> equipmentIds)
        {
            try
            {
                await _reservedAppointmentService.ReserveAppointment(appointmentId, userId, equipmentIds);

                return Ok("Appointment reserved successfully.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Error, ex, "User attempted to reserve an appointment that was already canceled.");
                return BadRequest("You cannot reserve an appointment that you have already canceled.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to reserve appointment");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while reserving the appointment.");
            }
        }

        [HttpPut("CancelAppointment/{appointmentId}")]
        public async Task<IActionResult> CancelAppointment(Guid appointmentId)
        {
            try
            {
                await _reservedAppointmentService.CancelAppointment(appointmentId);

                return Ok("Appointment canceled successfully.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to cancel appointment");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while canceling the appointment.");
            }
        }
    }
}
