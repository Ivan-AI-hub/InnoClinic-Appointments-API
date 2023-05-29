using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;

namespace AppointmentsAPI.Application.Abstraction
{
    public interface IAppointmentService
    {
        public Task<AppointmentDTO> AddAppointmentAsync(CreateAppointmentModel model, CancellationToken cancellationToken = default);
        public Task CancelAppointmentAsync(Guid Id, CancellationToken cancellationToken = default);
        public Task RescheduleAppointmentAsync(Guid Id, DoctorDTO doctor, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsHistoryAsync(Guid patientId, CancellationToken cancellationToken = default);
        public Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(int pageSize, int pageNumber,
            AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default);

    }

}
