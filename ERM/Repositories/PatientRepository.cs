using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task Delete(Patient entity)
        {
            _dbContext.Set<Patient>().Remove(entity);
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
