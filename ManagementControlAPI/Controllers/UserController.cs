using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ManagementControlAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using BCrypt;
using ManagementControlAPI.Data;

namespace ManagementControlAPI.Controllers
{
      [ApiController]
      [Route("api/v1/[controller]")]
      public class UserController : ControllerBase
      {
            private readonly DatabaseContext _context;

            public UserController(DatabaseContext context)
            {
                  _context = context;
            }


            [HttpGet("get")] // ==> localhost:3000/api/v1/user/get
            public IActionResult GetUsers()
            {
                  return Ok(_context.Users.ToList());
            }

            [HttpPost("login")] // ==> localhost:3000/api/v1/user/login
            public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
            {
                  User? user;

                  // Check if the identifier is an email or phone number
                  if (loginRequest.Identifier.Contains("@"))
                  {
                        user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Identifier);
                  }
                  else
                  {
                        user = _context.Users.FirstOrDefault(u => u.PhoneNumber == loginRequest.Identifier);
                  }

                  if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                        return Unauthorized(new { message = "Wrong login or password!" });

                  return Ok(new { message = "Logged in!", user });
            }

            [HttpPost("register")] // ==> localhost:3000/api/v1/user/register
            public IActionResult CreateUser([FromBody] User user)
            {
                  // Check if the user already exists
                  var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                  if (existingUser != null)
                  {
                        return BadRequest(new { message = "Użytkownik z tym emailem już istnieje." });
                  }

                  // Hash the password and save the user
                  user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                  _context.Add(user);
                  _context.SaveChanges();

                  return Created("", new { message = "Registered!", user });
            }
      }
}
