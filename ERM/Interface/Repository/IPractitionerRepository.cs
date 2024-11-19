using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IPractitionerRepository : IGenericRepository<Practitioner> 
    {
        Task Delete(Practitioner entity);
    }
}
