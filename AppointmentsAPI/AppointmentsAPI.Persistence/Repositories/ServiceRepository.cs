using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Exceptions;
using AppointmentsAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppointmentsContext _context;

        public ServiceRepository(AppointmentsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Service service, CancellationToken cancellationToken = default)
        {
            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, Service service, CancellationToken cancellationToken = default)
        {
            var dataService = await _context.Services.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (dataService == null)
            {
                throw new ServiceNotFoundException(id);
            }
            dataService.Name = service.Name;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
