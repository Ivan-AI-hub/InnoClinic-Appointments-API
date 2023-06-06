using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain;
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

        public async Task CreateAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            var service = new Service(id, name);
            await _serviceRepository.CreateAsync(service, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            var service = new Service(id, name);
            await _serviceRepository.UpdateAsync(id, service, cancellationToken);
        }
    }
}
