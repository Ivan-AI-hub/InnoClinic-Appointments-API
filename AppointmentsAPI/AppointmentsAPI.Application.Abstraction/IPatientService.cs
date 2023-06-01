namespace AppointmentsAPI.Application.Abstraction
{
    public interface IPatientService
    {
        public Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken);
    }
}
