using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task Delete(Location entity);
    }
}
