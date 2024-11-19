using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;

namespace ERM.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> AddLocation(LocationDto dto)
        {
            Location location = new Location();

            location.Name = dto.Name;
            location.Address = dto.Address;
            location.ClinicId = dto.ClinicId;

            return await _locationRepository.AddAsync(location);   
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            await _locationRepository.Delete(location);
            return true;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.ToList();
        }

        public async Task<Location> UpdateLocation(int id, LocationDto dto)
        {
            var location = await _locationRepository.GetByIdAsync(id);

            location.Name = dto.Name;
            location.Address = dto.Address;
            location.ClinicId = dto.ClinicId;

            return await _locationRepository.UpdateAsync(location);            
        }
    }
}
