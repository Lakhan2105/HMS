using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface IClinicAdminService
    {
        Task<List<ClinicAdmin>> GetAllClinicAdmins();

        Task<ClinicAdmin> AddClinicAdmin(ClinicAdminDto dto);

        Task<ClinicAdmin> UpdateClinicAdmin(int id, ClinicAdminDto dto);

        Task<bool> DeleteClinicAdmin(int id);
    }
}
