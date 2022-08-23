using Advent.Final.Contracts.Repository;
using Advent.Final.Core.V1;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advent.Final.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationCore _core;

        public AuthenticationController(ILogger<User> userLogger,IMapper mapper,IUserRepository userRepository,IConfiguration configuration)
        {
            _core = new(userRepository,userLogger,mapper,configuration);
        }
        // POST api/<AuthenticationController>
        [HttpPost]
        public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginRequestDto request)
        {
            var response= await _core.AuthUser(request);
            return StatusCode((int)response.StatusHttp, response);

        }


    }
}
