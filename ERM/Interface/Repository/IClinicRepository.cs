using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IClinicRepository : IGenericRepository<Clinic>
    {
        Task Delete(Clinic entity);
    }
}
