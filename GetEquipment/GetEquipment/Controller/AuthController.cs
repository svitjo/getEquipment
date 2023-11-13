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
        private readonly IAuthRepository authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            this.authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<int>> Register(DTORegisterUser request)
        {
            var response = await authRepo.Register(
                new User
                {
                    email = request.email,
                    password = request.password,
                    name = request.name,
                    lastname = request.lastname,
                    address = request.address,
                    city = request.city,
                    country = request.country,
                    phone = request.phone,
                    gender = request.gender,
                    company = request.company
                }
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}

