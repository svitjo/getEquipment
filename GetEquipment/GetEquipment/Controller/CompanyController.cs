using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetEquipment.Interface;
using GetEquipment.Model;

namespace GetEquipment.Controller
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetAll")]
        public ActionResult<Company> GetAll()
        {
            IEnumerable<Company> companies;
            try
            {
                companies = _companyService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get companies");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(companies);
        }

        [HttpGet]
        [Route("{companyID}")]
        public async Task<ActionResult> GetAsync([FromRoute] Guid companyID)
        {
            Company company;
            try
            {
                company = await _companyService.GetAsync(companyID);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get company");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(company);
        }
    }
}
