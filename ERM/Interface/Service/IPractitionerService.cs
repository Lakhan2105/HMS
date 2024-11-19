using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface IPractitionerService
    {
        Task<List<Practitioner>> GetAllPractitioners();

        Task<Practitioner> AddPractitioner(PractitionerDto dto);

        Task<Practitioner> UpdatePractitioner(int  id, PractitionerDto dto);

        Task<bool> DeletePractitioner(int id);
    }
}
