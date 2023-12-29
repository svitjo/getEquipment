using GetEquipment.DTOs;
using GetEquipment.Model;
using GetEquipment.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Controller
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<int>> Register(DTORegisterUser request)
        {
            var response = await _authRepo.Register(
                new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    Name = request.Name,
                    Lastname = request.Lastname,
                    Address = request.Address,
                    City = request.City,
                    Country = request.Country,
                    Phone = request.Phone,
                    Gender = request.Gender,
                    Company = request.Company
                }
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(User request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        /*
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await authRepo.ConfirmEmailAsync(userId, token);

            if (result.Success)
            {
                return Ok(new { message = "Email confirmed successfully" });
            }

            return BadRequest(result);
        }*/
    }
}

