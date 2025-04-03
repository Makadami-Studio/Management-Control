using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManagementControlAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementControlAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpPost("create")]
        public IActionResult CreateFlat([FromBody] Flat flat)
        {
            if (flat == null)
            {
                return BadRequest("Flat cannot be null.");
            }

            _flatService.CreateFlat(flat);
            return CreatedAtAction(nameof(GetFlatById), new { id = flat.Id }, flat);
        }

        [HttpGet("all")]
        public IActionResult GetAllFlats()
        {
            var flats = _flatService.GetAllFlats();
            return Ok(flats);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlat(int id)
        {
            _flatService.DeleteFlat(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlat(int id, [FromBody] Flat flat)
        {
            if (flat == null || flat.Id != id)
            {
                return BadRequest("Invalid flat data.");
            }

            _flatService.UpdateFlat(flat);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetFlatById(int id)
        {
            var flat = _flatService.GetFlatById(id);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }

        [HttpPost("{flatId}/users")]
        public IActionResult AddUserToFlat(int flatId, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            _flatService.AddUserToFlat(flatId, user);
            return NoContent();
        }

        [HttpDelete("{flatId}/users/{userId}")]
        public IActionResult RemoveUserFromFlat(int flatId, int userId)
        {
            _flatService.RemoveUserFromFlat(flatId, userId);
            return NoContent();
        }

        [HttpGet("{flatId}/users")]
        public IActionResult GetUsersInFlat(int flatId)
        {
            var users = _flatService.GetUsersInFlat(flatId);
            return Ok(users);
        }

        [HttpGet("{flatId}/tasks")]
        public IActionResult GetTasksInFlat(int flatId)
        {
            var tasks = _flatService.GetTasksInFlat(flatId);
            return Ok(tasks);
        }
    }

    public interface IFlatService
    {
        void AddUserToFlat(int flatId, User user);
        void CreateFlat(Flat flat);
        void DeleteFlat(int id);
        List<Flat> GetAllFlats();
        object GetFlatById(int id);
        object GetTasksInFlat(int flatId);
        object GetUsersInFlat(int flatId);
        void RemoveUserFromFlat(int flatId, int userId);
        void UpdateFlat(Flat flat);
    }
}