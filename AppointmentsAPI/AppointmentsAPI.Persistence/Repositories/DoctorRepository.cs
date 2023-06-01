using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppointmentsContext _context;

        public DoctorRepository(AppointmentsContext context)
        {
            _context = context;
        }

        public async Task UpdateFullNameAsync(Guid id, string firstName, string middleName, string lastName, CancellationToken cancellationToken = default)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (doctor == null)
            {
                throw new DoctorNotFoundException(id);
            }
            doctor.FirstName = firstName;
            doctor.MiddleName = middleName;
            doctor.LastName = lastName;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
