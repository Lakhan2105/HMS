using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task Delete(Appointment entity);
    }
}
