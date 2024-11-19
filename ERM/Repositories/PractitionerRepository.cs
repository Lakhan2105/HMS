using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class PractitionerRepository : GenericRepository<Practitioner>, IPractitionerRepository
    {
        public PractitionerRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task Delete(Practitioner entity)
        {
            _dbContext.Set<Practitioner>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
