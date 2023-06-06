using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Interfaces;

namespace AppointmentsAPI.Application
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task CreateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            var doctor = new Doctor(id, firstName, lastName, middleName);
            await _doctorRepository.CreateAsync(doctor, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _doctorRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            var doctor = new Doctor(id, firstName, lastName, middleName);
            await _doctorRepository.UpdateAsync(id, doctor, cancellationToken);
        }
    }
}
