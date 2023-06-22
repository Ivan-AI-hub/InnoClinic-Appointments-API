using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain;
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

        public async Task CreateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            var patient = new Patient(id, firstName, middleName, lastName);
            await _patientRepository.CreateAsync(patient, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _patientRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken)
        {
            var patient = new Patient(id, firstName, middleName, lastName);
            await _patientRepository.UpdateAsync(id, patient, cancellationToken);
        }
    }
}
