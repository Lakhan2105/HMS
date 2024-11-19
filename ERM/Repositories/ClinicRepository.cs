using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Delete(Clinic entity)
        {
            _dbContext.Set<Clinic>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
