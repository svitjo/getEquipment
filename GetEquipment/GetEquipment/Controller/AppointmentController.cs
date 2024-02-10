using GetEquipment.Interface;
using GetEquipment.Model;
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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentService appointmentService, ILogger<AppointmentController> logger)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetAllAppointmentsByAdmin")]
        [Route("{adminID}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointmentsByAdmin([FromRoute] Guid adminID)
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsByAdmin(adminID);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get appointments by admin");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAsync")]
        [Route("appointmentID")]
        public async Task<ActionResult<Appointment>> GetAsync([FromRoute] Guid appointmentID)
        {
            Appointment appointment;
            try
            {
                appointment = await _appointmentService.GetAsync(appointmentID);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get appointment");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(appointment);
        }

        [HttpGet("GetNonReservedAppointments")]
        [Route("{companyID}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetNonReservedAppointments([FromRoute] Guid companyID)
        {
            try
            {
                var appointments = await _appointmentService.GetNonReservedAppointments(companyID);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get appointments by admin");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAllAppointmentsByCompany")]
        [Route("{companyID}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointmentsByCompany([FromRoute] Guid companyID)
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsByCompany(companyID);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get appointments by admin");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
