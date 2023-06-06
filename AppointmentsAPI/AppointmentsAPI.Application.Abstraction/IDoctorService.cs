namespace AppointmentsAPI.Application.Abstraction
{
    public interface IDoctorService
    {
        public Task UpdateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken);
        public Task CreateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
