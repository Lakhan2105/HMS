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

    [Authorize(Roles = "clinicAdmin")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IClinicService _clinicService;
        private readonly ApplicationDbContext _dbContext;

        public ClinicController(IClinicService clinicService, IClinicRepository clinicRepository, ApplicationDbContext dbContext)
        {
            _clinicRepository = clinicRepository;
            _clinicService = clinicService;
            _dbContext = dbContext;
        }

        // GET: api/<ClinicController>
        [HttpGet("GetAllClinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            var result = await _clinicService.GetAllClinics();
            return Ok(result);
        }

        // GET api/<ClinicController>/5
        [HttpGet("GetClinicById/{clinicId}")]
        public async Task<IActionResult> GetClinicById(int clinicId)
        {
            var clinic = await _dbContext.Clinics
                          .Where(x => x.ClinicId == clinicId)
                          .ToListAsync();

            if (clinic == null)
            {
                return NotFound("Clinic Not Exist");
            }

            return new OkObjectResult(clinic);
        }

        // POST api/<ClinicController>
        [HttpPost("AddClinic")]
        public async Task<IActionResult> AddAsync([FromBody] ClinicDto dto)
        {
            var result = await _clinicService.GetAllClinics();
            return Ok(result);
        }

        // PUT api/<ClinicController>/5
        [HttpPut("UpdateClinic")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClinicDto dto)
        {
            var result = await _clinicService.UpdateClinic(id, dto);
            return Ok(result);
        }

        // DELETE api/<ClinicController>/5
        [HttpDelete("DeleteClinic")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            var result = await _clinicService.DeleteClinic(id);
            return NoContent();
        }
    }
}
