using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ManagementControlAPI.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ManagementControlAPI.Controllers
{
      [ApiController]
      [Route("api/v1/[controller]")]
      public class UserController : ControllerBase
      {
            private static List<User> users = new();
            private static int nextId = 1;

            [Authorize]
            [HttpGet]
            public IActionResult GetUsers()
            {
                  return Ok(users);
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
            {
                  var user = users.FirstOrDefault(u =>
                  u.Login == loginRequest.Login &&
                  u.Password == loginRequest.Password);

                  if (user == null)
                        return Unauthorized(new { message = "Wrong login or password!" });

                  return Ok(new { message = "Logged in!", user });
            }

            [HttpPost("register")]
            public IActionResult CreateUser([FromBody] User user)
            {
                  user.Id = nextId++;
                  users.Add(user);
                  return Created("", new { message = "Registered!", user });
            }
      }
}
