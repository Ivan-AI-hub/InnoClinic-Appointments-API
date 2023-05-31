namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public Task RescheduleAsync(Guid id, Doctor doctor, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default);
        public Task ApproveAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<Appointment>> GetAppointmentsAsync(int pageSize, int pageNumber, IFiltrator<Appointment> filtrator,
                                                              CancellationToken cancellationToken = default);
    }
}
