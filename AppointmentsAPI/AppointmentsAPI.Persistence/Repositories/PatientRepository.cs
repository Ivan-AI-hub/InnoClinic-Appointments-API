using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentsContext _context;

        public PatientRepository(AppointmentsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            await _context.Patients.AddAsync(patient, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (patient == null)
            {
                throw new PatientNotFoundException(id);
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, Patient patient, CancellationToken cancellationToken = default)
        {
            var dataPatient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (dataPatient == null)
            {
                throw new PatientNotFoundException(id);
            }
            dataPatient.FirstName = patient.FirstName;
            dataPatient.MiddleName = patient.MiddleName;
            dataPatient.LastName = patient.LastName;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
