using AppointmentsAPI.Application.Abstraction.Models;

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
        /// Edits the appointment's doctor and Date with Time for appointment 
        /// </summary>
        public Task RescheduleAppointmentAsync(Guid id, RescheduleAppointmentModel model, CancellationToken cancellationToken = default);
        /// <summary>
        /// Approves appointment
        /// </summary>
        public Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(int pageSize, int pageNumber,
            AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default);

        public Task<AppointmentDTO> GetAppointmentAsync(Guid id, CancellationToken cancellationToken = default);
    }

}
