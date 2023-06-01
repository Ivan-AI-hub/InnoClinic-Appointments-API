namespace AppointmentsAPI.Application.Abstraction
{
    public interface IDoctorService
    {
        public Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken);
    }
}
