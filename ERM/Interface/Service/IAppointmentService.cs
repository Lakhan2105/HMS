using ERM.Dtos;
using ERM.Models;

namespace ERM.Interface.Service
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointments();

        Task<Appointment> AddAppointment(AppointmentDto dto);

        Task<Appointment> UpdateAppointment(int id, AppointmentDto dto);

        Task<bool> DeleteAppointment(int id);
    }
}
