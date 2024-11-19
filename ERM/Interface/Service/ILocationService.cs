using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocations();

        Task<Location> AddLocation(LocationDto dto);

        Task<Location> UpdateLocation(int id, LocationDto dto);

        Task<bool> DeleteLocation(int id);
    }
}
