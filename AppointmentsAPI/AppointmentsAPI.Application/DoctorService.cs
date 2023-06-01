using AppointmentsAPI.Application.Abstraction;
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

        public async Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            await _doctorRepository.UpdateFullNameAsync(id, firstName, middleName, lastName, cancellationToken);
        }
    }
}
