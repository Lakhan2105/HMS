using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface IClinicService
    {
        Task<List<Clinic>> GetAllClinics();

        Task<Clinic> AddClinic(ClinicDto dto);

        Task<Clinic> UpdateClinic(int id, ClinicDto dto);

        Task<bool> DeleteClinic(int id);
    }
}
