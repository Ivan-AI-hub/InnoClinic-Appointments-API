namespace AppointmentsAPI.Application.Abstraction
{
    public interface IServiceService
    {
        public Task UpdateAsync(Guid id, string name, CancellationToken cancellationToken);
        public Task CreateAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
