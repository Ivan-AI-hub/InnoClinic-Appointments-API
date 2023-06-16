namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IPatientRepository
    {
        public Task UpdateAsync(Guid id, Patient patient, CancellationToken cancellationToken = default);
        public Task CreateAsync(Patient patient, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
