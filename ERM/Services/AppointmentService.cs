using ERM.Dtos;
using ERM.Interface.Repository;
using ERM.Interface.Service;
using ERM.Models;
using ERM.Repositories;

namespace ERM.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> AddAppointment(AppointmentDto dto)
        {
            Appointment appointment = new Appointment();

            appointment.Date = dto.Date;
            appointment.Status = dto.Status;
            appointment.ClinicId = dto.ClinicId;
            appointment.LocationId = dto.LocationId;
            appointment.PatientId = dto.PatientId;
            appointment.PractitionerId = dto.PractitionerId;

            return await _appointmentRepository.AddAsync(appointment);
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            await _appointmentRepository.Delete(appointment);
            return true;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return appointments.ToList();
        }

        public async Task<Appointment> UpdateAppointment(int id, AppointmentDto dto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            appointment.Date = dto.Date;
            appointment.Status = dto.Status;
            appointment.ClinicId = dto.ClinicId;
            appointment.LocationId = dto.LocationId;
            appointment.PatientId = dto.PatientId;
            appointment.PractitionerId = dto.PractitionerId;

            return await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
