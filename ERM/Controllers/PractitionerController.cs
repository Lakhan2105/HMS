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

    [Authorize(Roles = "practitioner, clinicAdmin")]
    public class PractitionerController : ControllerBase
    {
        private readonly IPractitionerRepository _practitionerRepository;
        private readonly IPractitionerService _practitionerService;
        private readonly ApplicationDbContext _dbContext;

        public PractitionerController(IPractitionerService practitionerService, IPractitionerRepository practitionerRepository, ApplicationDbContext dbContext)
        {
            _practitionerRepository = practitionerRepository;
            _practitionerService = practitionerService;
            _dbContext = dbContext;
        }

        // GET: api/<PractitionerController>
        [HttpGet("GetAllPractitioners")]
        public async Task<IActionResult> GetAllPractitioners()
        {
            var result = await _practitionerService.GetAllPractitioners();
            return Ok(result);
        }

        // GET api/<PractitionerController>/5
        [HttpGet("GetPractitionerById/{practitionerId}")]
        public async Task<IActionResult> GetPractitionerById(int practitionerId)
        {
            var practitioner = await _dbContext.Practitioners
                          .Where(x => x.PractitionerId == practitionerId)
                          .ToListAsync();

            if (practitioner == null)
            {
                return NotFound("Practitioner Not Exist");
            }

            return new OkObjectResult(practitioner);
        }

        // POST api/<PractitionerController>
        [HttpPost("AddPractitioner")]
        public async Task<IActionResult> AddAsync([FromBody] PractitionerDto dto)
        {
            var result = await _practitionerService.AddPractitioner(dto);
            return Ok(result);
        }

        // PUT api/<PractitionerController>/5
        [HttpPut("UpdatePractitioner")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PractitionerDto dto)
        {
            var result = await _practitionerService.UpdatePractitioner(id, dto);
            return Ok(result);
        }

        // DELETE api/<PractitionerController>/5
        [HttpDelete("DeletePractitioner")]
        public async Task<IActionResult> DeletePractitioner(int id)
        {
            var result = await _practitionerService.DeletePractitioner(id);
            return NoContent();
        }
    }
}
