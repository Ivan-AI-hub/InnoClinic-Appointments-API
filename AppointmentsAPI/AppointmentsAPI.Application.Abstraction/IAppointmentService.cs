using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;

namespace AppointmentsAPI.Application.Abstraction
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Adds appointment into database
        /// </summary>
        public Task<AppointmentDTO> AddAppointmentAsync(CreateAppointmentModel model, CancellationToken cancellationToken = default);
        /// <summary>
        /// Cancels appointment
        /// </summary>
        public Task CancelAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Edits the appointment's doctor and date with time for appointment 
        /// </summary>
        public Task RescheduleAppointmentAsync(Guid id, Guid doctorId, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default);
        /// <summary>
        /// Approves appointment
        /// </summary>
        public Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(int pageSize, int pageNumber,
            AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default);

    }

}
