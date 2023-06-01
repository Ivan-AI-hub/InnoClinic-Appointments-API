namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        public Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken = default);
    }
}
