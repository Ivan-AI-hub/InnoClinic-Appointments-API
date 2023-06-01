namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IPatientRepository
    {
        public Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken = default);
    }
}
