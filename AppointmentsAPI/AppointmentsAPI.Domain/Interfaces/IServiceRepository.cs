namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IServiceRepository
    {
        public Task UpdateNameAsync(Guid id, string name, CancellationToken cancellationToken = default);
    }
}
