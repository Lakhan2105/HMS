using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class ClinicAdminRepository : GenericRepository<ClinicAdmin>, IClinicAdminRepository
    {
        public ClinicAdminRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Delete(ClinicAdmin entity)
        {
            _dbContext.Set<ClinicAdmin>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
