using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userFor) 
        {
            userFor.Username = userFor.Username.ToLower();
            if(await _repo.UserExists(userFor.Username))
            {
                return BadRequest("Username already exists");
            }
            var userToCreate = new User 
            {
                Username = userFor.Username
            };
            var createdUser = await _repo.Register(userToCreate, userFor.Password);

            return StatusCode(201);
        }
    }
}