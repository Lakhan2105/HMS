using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;

namespace ERM.Services
{
    public class PractitionerService : IPractitionerService

    {
        private readonly IPractitionerRepository _practitionerRepository;

        public PractitionerService(IPractitionerRepository practitionerRepository)
        {
            _practitionerRepository = practitionerRepository;
        }

        public async Task<Practitioner> AddPractitioner(PractitionerDto dto)
        {
            Practitioner practitioner = new Practitioner();

            practitioner.FirstName = dto.FirstName;
            practitioner.MiddleName = dto.MiddleName;
            practitioner.LastName = dto.LastName;
            practitioner.DateOfBirth = dto.DateOfBith;
            practitioner.Phone = dto.Phone;
            practitioner.Email = dto.Email;
            practitioner.ClinicId = dto.ClinicId;
            practitioner.UserId = dto.UserId;

            return await _practitionerRepository.AddAsync(practitioner);
        }

        public async Task<bool> DeletePractitioner(int id)
        {
            var practitioner = await _practitionerRepository.GetByIdAsync(id);
            await _practitionerRepository.Delete(practitioner);
            return true;
        }

        public async Task<List<Practitioner>> GetAllPractitioners()
        {
            var practitioners = await _practitionerRepository.GetAllAsync();
            return practitioners.ToList();
        }

        public async Task<Practitioner> UpdatePractitioner(int id, PractitionerDto dto)
        {
            var practitioner = await _practitionerRepository.GetByIdAsync(id);

            practitioner.FirstName = dto.FirstName;
            practitioner.MiddleName = dto.MiddleName;
            practitioner.LastName = dto.LastName;
            practitioner.DateOfBirth = dto.DateOfBith;
            practitioner.Phone = dto.Phone;
            practitioner.Email = dto.Email;
            practitioner.ClinicId = dto.ClinicId;
            practitioner.UserId = dto.UserId;

            return await _practitionerRepository.UpdateAsync(practitioner);
        }
    }
}
