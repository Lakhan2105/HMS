using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IClinicAdminRepository : IGenericRepository<ClinicAdmin>
    {
        Task Delete(ClinicAdmin entity);
    }
}
