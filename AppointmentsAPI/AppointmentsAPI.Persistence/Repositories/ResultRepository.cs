using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private AppointmentsContext _appointmentsContext;

        public ResultRepository(AppointmentsContext appointmentsContext)
        {
            _appointmentsContext = appointmentsContext;
        }
        public async Task CreateAsync(Result result, CancellationToken cancellationToken = default)
        {
            if(!_appointmentsContext.Appointments.Any(x => x.Id == result.AppointmentId))
            {
                throw new AppointmentNotFoundException(result.AppointmentId);
            }
            await _appointmentsContext.Results.AddAsync(result, cancellationToken);
            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> GetByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default)
        {
            var result = await GetFullDataResults()
                                    .Where(x => x.AppointmentId == appointmentId)
                                    .FirstOrDefaultAsync(cancellationToken);
            if(result == null)
            {
                throw new ResultForAppointmentNotFoundException(appointmentId);
            }

            return result;
        }

        public async Task UpdateAsync(Guid id, string complaints, string conclusion,
                                      string recomendations, CancellationToken cancellationToken = default)
        {
            Result? result = await _appointmentsContext.Results
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
            {
                throw new ResultNotFoundException(id);
            }
            result.Complaints = complaints;
            result.Conclusion = conclusion;
            result.Recomendations = recomendations;

            await _appointmentsContext.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<Result> GetFullDataResults()
        {
            return _appointmentsContext.Results.Include(x => x.Appointment)
                                                    .ThenInclude(x => x.Patient)
                                               .Include(x => x.Appointment)
                                                    .ThenInclude(x => x.Doctor)
                                               .Include(x => x.Appointment)
                                                    .ThenInclude(x => x.Service)
                                               .AsNoTracking();
        }

    }
}
