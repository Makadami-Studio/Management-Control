using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementControlAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace ManagementControlAPI.Controllers

{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PingController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public PingController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("db")] // ==> localhost:3000/api/v1/ping/db
        public IActionResult CheckDbConnection()
        {
            try
            {
                var canConnect = _db.Database.CanConnect();
                if (canConnect == true)
                {
                    return Ok(new { dbConnected = canConnect });
                }
                else
                {
                    return NotFound(new { dbConnected = canConnect });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "DB NOT connected", error = ex.Message });
            }
        }
    }
}