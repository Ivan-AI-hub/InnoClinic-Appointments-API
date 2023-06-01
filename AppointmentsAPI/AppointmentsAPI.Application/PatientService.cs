using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain.Interfaces;

namespace AppointmentsAPI.Application
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            await _patientRepository.UpdateFullNameAsync(id, firstName, middleName, lastName, cancellationToken);
        }
    }
}
