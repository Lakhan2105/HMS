using ERM.Data;
using ERM.Interface.Repository;
using ERM.Models;

namespace ERM.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Delete(Appointment entity)
        {
            _dbContext.Set<Appointment>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
