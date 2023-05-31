using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;

namespace AppointmentsAPI.Application.Abstraction
{
    public interface IAppointmentService
    {
        public Task<AppointmentDTO> AddAppointmentAsync(CreateAppointmentModel model, CancellationToken cancellationToken = default);
        public Task CancelAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        public Task RescheduleAppointmentAsync(Guid id, Guid doctorId, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default);
        public Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(int pageSize, int pageNumber,
            AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default);

    }

}
