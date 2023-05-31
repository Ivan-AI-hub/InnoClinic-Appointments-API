using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private AppointmentsContext _appointmentsContext;

        public AppointmentRepository(AppointmentsContext appointmentsContext)
        {
            _appointmentsContext = appointmentsContext;
        }

        public async Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            await _appointmentsContext.Appointments.AddAsync(appointment, cancellationToken);
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ApproveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentsContext.Appointments
                                                        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(id);
            }

            appointment.IsApproved = true;
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentsContext.Appointments
                                                        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(id);
            }

            _appointmentsContext.Remove(appointment);
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(int pageSize, int pageNumber, IFiltrator<Appointment> filtrator, CancellationToken cancellationToken = default)
        {
            var appointments = GetFullDataAppointments();
            appointments = filtrator.Filtrate(appointments);
            appointments = appointments.OrderBy(x => x.Date);
            appointments = appointments.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            return await appointments.ToListAsync(cancellationToken);

        }

        public async Task RescheduleAsync(Guid id, Doctor doctor, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentsContext.Appointments
                                            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(id);
            }

            appointment.Doctor = doctor;
            appointment.Date = date;
            appointment.Time = time;
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<Appointment> GetFullDataAppointments()
        {
            return _appointmentsContext.Appointments.Include(x => x.Service)
                                                    .Include(x => x.Patient)
                                                    .Include(x => x.Doctor)
                                                    .Include(x => x.Result)
                                                    .AsNoTracking();
        }

    }
}
