using ERM.Data;
using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "patient, practitioner, clinicAdmin")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _dbContext;

        public AppointmentController(IAppointmentService appointmentService, IAppointmentRepository appointmentRepository, ApplicationDbContext dbContext)
        {
             _appointmentRepository = appointmentRepository;
            _appointmentService = appointmentService;
            _dbContext = dbContext;
        }

        // GET: api/<AppointmentController>
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _appointmentService.GetAllAppointments();
            return Ok(result);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("GetAppointmentById/{appointmentId}")]
        public async Task<IActionResult> GetAppointmentById(int appointmentId)
        {
            var appointment = await _dbContext.Appointments
                          .Where(x => x.AppointmentId == appointmentId)
                          .ToListAsync();

            if (appointment == null)
            {
                return NotFound("Appointment Not Exist");
            }

            return new OkObjectResult(appointment);
        }

        // POST api/<AppointmentController>
        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentDto dto)
        {
            var result = await _appointmentService.AddAppointment(dto);
            return Ok(result);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("UpdateAppointment")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto dto)
        {
            var result = await _appointmentService.UpdateAppointment(id, dto);
            return Ok(result);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }
}
