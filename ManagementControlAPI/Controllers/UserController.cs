using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ManagementControlAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using BCrypt;

namespace ManagementControlAPI.Controllers
{
      [ApiController]
      [Route("api/v1/[controller]")]
      public class UserController : ControllerBase
      {
            private static List<User> users = new();
            private static int nextId = 1;
            
            [HttpGet("get")] // ==> localhost:3000/api/v1/user/get
            public IActionResult GetUsers()
            {
                  return Ok(users);
            }

            [HttpPost("login")] // ==> localhost:3000/api/v1/user/login
            public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
            {
                  var user = users.FirstOrDefault(u => u.Login == loginRequest.Login);

                  if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                        return Unauthorized(new { message = "Wrong login or password!" });

                  return Ok(new { message = "Logged in!", user });
            }

            [HttpPost("register")] // ==> localhost:3000/api/v1/user/register
            public IActionResult CreateUser([FromBody] User user)
            {
                  user.Id = nextId++;
                  user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                  users.Add(user);
                  return Created("", new { message = "Registered!", user });
            }
      }
}
