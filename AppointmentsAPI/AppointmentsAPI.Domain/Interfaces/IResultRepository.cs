namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IResultRepository
    {
        public Task CreateAsync(Result result, CancellationToken cancellationToken = default);
        public Task UpdateAsync(Guid id, Result result, CancellationToken cancellationToken = default);
        public Task<Result> GetByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default);
    }
}
