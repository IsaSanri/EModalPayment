﻿using Advent.Final.Contracts.Repository;
using Advent.Final.Core.V1;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advent.Final.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthtenticationController : ControllerBase
    {
        private readonly AuthtenticationCore _core;

        public AuthtenticationController(ILogger<User> userLogger,IMapper mapper,IUserRepository userRepository,IConfiguration configuration)
        {
            _core = new(userRepository,userLogger,mapper,configuration);
        }
        // POST api/<AuthtenticationController>
        [HttpPost]
        public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginRequestDto request)
        {
            var response= await _core.AuthUser(request);
            return StatusCode((int)response.StatusHttp, response);

        }

        [HttpPost("password")]
        public async Task<ActionResult<bool>> AddPassword([FromBody] UserLoginRequestDto request) 
        {
            var response = await _core.AddPassword(request);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPut("password")]
        public async Task<ActionResult<bool>> ResetPassword([FromBody] UserChangePasswordDto request)
        {
            var response = await _core.ResetPassword(request);
            return StatusCode((int)response.StatusHttp, response);
        }

    }
}
