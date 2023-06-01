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

        public async Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken = default)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (patient == null)
            {
                //do something
                throw new PatientNotFoundException(id);
            }
            patient.FirstName = firstName;
            patient.MiddleName = middleName;
            patient.LastName = lastName;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
