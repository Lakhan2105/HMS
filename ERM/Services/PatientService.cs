using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;
using ERM.Repositories;

namespace ERM.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> AddPatient(PatientDto dto)
        {
            Patient patient = new Patient();
            patient.FirstName = dto.FirstName;
            patient.MiddleName = dto.MiddleName;
            patient.LastName = dto.LastName;
            patient.DateOfBirth = dto.DateOfBirth;
            patient.Phone = dto.Phone;
            patient.Email = dto.Email;
            patient.ClinicId = dto.ClinicId;
            patient.PractitionerId = dto.PractitionerId;
            patient.UserId = dto.UserId;

            return await _patientRepository.AddAsync(patient);
        }

        public async Task<bool> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            await _patientRepository.Delete(patient);
            return true;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            return patients.ToList();
        }

        public async Task<Patient> UpdatePatient(int id, PatientDto dto)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            patient.FirstName = dto.FirstName;
            patient.MiddleName = dto.MiddleName;
            patient.LastName = dto.LastName;
            patient.DateOfBirth= dto.DateOfBirth;
            patient.Phone = dto.Phone;
            patient.Email = dto.Email;
            patient.ClinicId= dto.ClinicId;
            patient.PractitionerId= dto.PractitionerId;
            patient.UserId= dto.UserId;

            return await _patientRepository.UpdateAsync(patient);
        }
    }
}
