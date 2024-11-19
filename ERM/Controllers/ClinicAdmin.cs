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

    [Authorize (Roles = "clinicAdmin")]
    public class ClinicAdmin : ControllerBase
    {
        private readonly IClinicAdminService _clinicAdminService;
        private readonly IClinicAdminRepository _clinicAdminRepository;
        private readonly ApplicationDbContext _dbContext;

        public ClinicAdmin(IClinicAdminRepository clinicAdminRepository, IClinicAdminService clinicAdminService, ApplicationDbContext dbContext)
        {
            _clinicAdminService = clinicAdminService;
            _clinicAdminRepository = clinicAdminRepository;
            _dbContext = dbContext;
        }

        // GET: api/<ClinicAdmin>
        [HttpGet("GetAllClinicAdmins")]
        public async Task<IActionResult> GetAllClinicAdmins()
        {
            var result = await _clinicAdminService.GetAllClinicAdmins();
            return Ok(result);
        }

        // GET api/<ClinicAdmin>/5
        [HttpGet("GetClinicAdminById/{clinicAdminId}")]
        public async Task<IActionResult> GetClinicAdminById(int clinicAdminId)
        {
            var clinicAdmin = await _dbContext.ClinicAdmins
                          .Where(x => x.ClinicAdminId == clinicAdminId)
                          .ToListAsync();

            if (clinicAdmin == null)
            {
                return NotFound("ClinicAdmin Not Exist");
            }

            return new OkObjectResult(clinicAdmin);
        }

        // POST api/<ClinicAdmin>
        [HttpPost("AddClinicAdmin")]
        public async Task<IActionResult> AddAsync([FromBody] ClinicAdminDto dto)
        {
            var result = await _clinicAdminService.AddClinicAdmin(dto);
            return Ok(result);
        }

        // PUT api/<ClinicAdmin>/5
        [HttpPut("UpdateClinicAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClinicAdminDto dto)
        {
            var result = await _clinicAdminService.UpdateClinicAdmin(id, dto);
            return Ok(result);
        }

        // DELETE api/<ClinicAdmin>/5
        [HttpDelete("DeleteClinicAdmin")]
        public async Task<IActionResult> DeleteClinicAdmin(int id)
        {
            var result = await _clinicAdminService.DeleteClinicAdmin(id);
            return NoContent();
        }
    }
}
