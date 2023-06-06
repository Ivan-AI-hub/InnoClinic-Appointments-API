namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        public Task UpdateAsync(Guid id, Doctor doctor, CancellationToken cancellationToken = default);
        public Task CreateAsync(Doctor doctor, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
