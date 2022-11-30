using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Dto;
using Shipping.UnitOfWork;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LogInUserDto logInUserDto)
        {
            var user = _unitOfWork.UserRepository.Login(logInUserDto);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _unitOfWork.UserRepository.GenerateToken(user);
            _unitOfWork.Complete();
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest("Invalid request");
            }
            _unitOfWork.UserRepository.Register(createUserDto);
            _unitOfWork.Complete();
            return Ok("User has been registered successfully");
        }

        
    }
}