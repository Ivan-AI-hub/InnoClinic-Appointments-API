namespace AppointmentsAPI.Application.Abstraction
{
    public interface IServiceService
    {
        public Task UpdateNameAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
