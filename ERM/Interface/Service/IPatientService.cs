using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();

        Task<Patient> AddPatient(PatientDto dto);

        Task<Patient> UpdatePatient(int id, PatientDto dto);

        Task<bool> DeletePatient(int id);
    }
}
