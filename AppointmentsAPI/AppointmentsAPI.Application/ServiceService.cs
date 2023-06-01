using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain.Interfaces;

namespace AppointmentsAPI.Application
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task UpdateNameAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            await _serviceRepository.UpdateNameAsync(id, name, cancellationToken);
        }
    }
}
