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

        public async Task UpdateNameAsync(Guid id, string name, CancellationToken cancellationToken = default)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (service == null)
            {
                throw new ServiceNotFoundException(id);
            }
            service.Name = name;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
