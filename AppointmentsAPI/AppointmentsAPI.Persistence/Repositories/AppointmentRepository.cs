using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentsContext _appointmentsContext;

        public AppointmentRepository(AppointmentsContext appointmentsContext)
        {
            _appointmentsContext = appointmentsContext;
        }

        public async Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            if (!await _appointmentsContext.Doctors.AnyAsync(x => x.Id == appointment.DoctorId))
            {
                throw new DoctorNotFoundException(appointment.DoctorId);
            }

            if (!await _appointmentsContext.Patients.AnyAsync(x => x.Id == appointment.PatientId))
            {
                throw new PatientNotFoundException(appointment.PatientId);
            }

            if (!await _appointmentsContext.Services.AnyAsync(x => x.Id == appointment.ServiceId))
            {
                throw new ServiceNotFoundException(appointment.ServiceId);
            }

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

        public async Task<Appointment> GetAppointmentById(Guid id, CancellationToken cancellationToken)
        {
            var appointment = await GetFullDataAppointments().FirstOrDefaultAsync(x => x.Id == id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(id);
            }
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(int pageSize, int pageNumber, IFiltrator<Appointment> filtrator, CancellationToken cancellationToken = default)
        {
            var appointments = GetFullDataAppointments();
            appointments = filtrator.Filtrate(appointments);
            appointments = appointments.OrderByDescending(x => x.Date);
            appointments = appointments.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            return await appointments.ToListAsync(cancellationToken);

        }

        public async Task RescheduleAsync(Guid id, Guid doctorId, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default)
        {
            if (!await _appointmentsContext.Doctors.AnyAsync(x => x.Id == doctorId))
            {
                throw new DoctorNotFoundException(doctorId);
            }

            var appointment = await _appointmentsContext.Appointments
                                            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(id);
            }
            if (appointment.IsApproved == true)
            {
                throw new AppointmentAlreadyApproved(id);
            }

            appointment.DoctorId = doctorId;
            appointment.Date = date;
            appointment.Time = time;
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<Appointment> GetFullDataAppointments()
        {
            return _appointmentsContext.Appointments.Include(x => x.Service)
                                                    .Include(x => x.Patient)
                                                    .Include(x => x.Doctor)
                                                    .AsNoTracking();
        }

    }
}
