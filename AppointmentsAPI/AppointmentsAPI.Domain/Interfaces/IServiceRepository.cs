namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IServiceRepository
    {
        public Task UpdateAsync(Guid id, Service service, CancellationToken cancellationToken = default);
        public Task CreateAsync(Service service, CancellationToken cancellationToken = default);
    }
}
