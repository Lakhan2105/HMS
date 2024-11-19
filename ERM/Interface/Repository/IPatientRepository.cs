using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
        Task Delete(Patient entity);
    }
}
