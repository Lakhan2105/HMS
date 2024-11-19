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
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationService _locationService;
        private readonly ApplicationDbContext _dbContext;

        public LocationController(ILocationService locationService, ILocationRepository locationRepository, ApplicationDbContext dbContext)
        {
            _locationService = locationService;
            _locationRepository = locationRepository;
            _dbContext = dbContext;
        }

        // GET: api/<LocationController>
        [HttpGet("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _locationService.GetAllLocations();
            return Ok(result);
        }

        // GET api/<LocationController>/5
        [HttpGet("GetLocationById/{locationId}")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var location = await _dbContext.Locations
                          .Where(x => x.LocationId == locationId)
                          .ToListAsync();

            if (location == null)
            {
                return NotFound("Location Not Exist");
            }

            return new OkObjectResult(location);
        }

        // POST api/<LocationController>
        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto dto)
        {
            var result = await _locationService.AddLocation(dto);
            return Ok(result);
        }

        // PUT api/<LocationController>/5
        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto dto)
        {
            var result = await _locationService.UpdateLocation(id, dto);
            return Ok(result);
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _locationService.DeleteLocation(id);
            return NoContent();
        }
    }
}
