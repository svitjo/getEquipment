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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
        {
            _equipmentService = equipmentService ?? throw new ArgumentNullException(nameof(equipmentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetAll")]
        public ActionResult<Equipment> GetAll()
        {
            IEnumerable<Equipment> equipments;
            try
            {
                equipments = _equipmentService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get companies");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(equipments);
        }

        [HttpGet]
        [Route("{companyID}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAllEquipmentByCompany([FromRoute] Guid companyID)
        {
            try
            {
                var equipments = await _equipmentService.GetAllEquipmentByCompany(companyID);
                return Ok(equipments);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get equipment for the company");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}