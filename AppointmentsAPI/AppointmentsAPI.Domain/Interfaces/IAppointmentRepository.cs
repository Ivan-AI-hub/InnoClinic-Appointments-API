namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Adds appointment into database
        /// </summary>
        public Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default);
        /// <summary>
        /// Deletes appointment
        /// </summary>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Edits the appointment's doctor and date with time for appointment 
        /// </summary>
        public Task RescheduleAsync(Guid id, Guid doctorId, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default);
        /// <summary>
        /// Approves appointment
        /// </summary>
        public Task ApproveAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<Appointment>> GetAppointmentsAsync(int pageSize, int pageNumber, IFiltrator<Appointment> filtrator,
                                                              CancellationToken cancellationToken = default);
    }
}
