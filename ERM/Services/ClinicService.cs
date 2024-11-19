using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;

namespace ERM.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }
        public async Task<Clinic> AddClinic(ClinicDto dto)
        {
            Clinic clinic = new Clinic();

            clinic.Name = dto.Name;
            clinic.Address = dto.Address;
            clinic.Email = dto.Email;

            return await _clinicRepository.AddAsync(clinic);
        }

        public async Task<bool> DeleteClinic(int id)
        {
            var clinic = await _clinicRepository.GetByIdAsync(id);
            await _clinicRepository.Delete(clinic);
            return true;
        }

        public async Task<List<Clinic>> GetAllClinics()
        {
            var clinics = await _clinicRepository.GetAllAsync();
            return clinics.ToList();
        }

        public async Task<Clinic> UpdateClinic(int id, ClinicDto dto)
        {
            var clinic = await _clinicRepository.GetByIdAsync(id);

            clinic.Name = dto.Name;
            clinic.Address = dto.Address;
            clinic.Email = dto.Email;

            return await _clinicRepository.UpdateAsync(clinic);
        }
    }
}
