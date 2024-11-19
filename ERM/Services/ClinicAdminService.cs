using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;

namespace ERM.Services
{
    public class ClinicAdminService : IClinicAdminService
    {
        private readonly IClinicAdminRepository _clinicAdminRepository;

        public ClinicAdminService(IClinicAdminRepository clinicAdminRepository)
        {
            _clinicAdminRepository = clinicAdminRepository;    
        }

        public async Task<ClinicAdmin> AddClinicAdmin(ClinicAdminDto dto)
        {
            ClinicAdmin clinicAdmin = new ClinicAdmin();

            clinicAdmin.FirstName = dto.FirstName;
            clinicAdmin.MiddleName = dto.MiddleName;
            clinicAdmin.LastName = dto.LastName;
            clinicAdmin.DateOfBirth = dto.DateOfBirth;
            clinicAdmin.Phone = dto.Phone;
            clinicAdmin.Email = dto.Email;
            clinicAdmin.ClinicId = dto.ClinicId;
            clinicAdmin.UserId = dto.UserId;

            return await _clinicAdminRepository.AddAsync(clinicAdmin);
        }

        public async Task<bool> DeleteClinicAdmin(int id)
        {
            var clinicAdmin = await _clinicAdminRepository.GetByIdAsync(id);
            _clinicAdminRepository.Delete(clinicAdmin);
            return true;
        }

        public async Task<List<ClinicAdmin>> GetAllClinicAdmins()
        {
            var clinicAdmins = await _clinicAdminRepository.GetAllAsync();
            return clinicAdmins.ToList();
        }

        public async Task<ClinicAdmin> UpdateClinicAdmin(int id, ClinicAdminDto dto)
        {
            var clinicAdmin = await _clinicAdminRepository.GetByIdAsync(id);

            clinicAdmin.FirstName = dto.FirstName;
            clinicAdmin.MiddleName = dto.MiddleName;
            clinicAdmin.LastName = dto.LastName;
            clinicAdmin.DateOfBirth = dto.DateOfBirth;
            clinicAdmin.Phone = dto.Phone;
            clinicAdmin.Email = dto.Email;
            clinicAdmin.ClinicId = dto.ClinicId;
            clinicAdmin.UserId = dto.UserId;

            return await _clinicAdminRepository.UpdateAsync(clinicAdmin);
        }
    }
}
