using AppointmentsAPI.Domain;
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

        public async Task CreateAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            await _context.Doctors.AddAsync(doctor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (doctor == null)
            {
                throw new DoctorNotFoundException(id);
            }
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, Doctor doctor, CancellationToken cancellationToken = default)
        {
            var dataDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (dataDoctor == null)
            {
                throw new DoctorNotFoundException(id);
            }
            dataDoctor.FirstName = doctor.FirstName;
            dataDoctor.MiddleName = doctor.MiddleName;
            dataDoctor.LastName = doctor.LastName;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
