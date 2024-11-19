using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Delete(Location entity)
        {
            _dbContext.Set<Location>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
