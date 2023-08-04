using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class ServiceCreatedConsumer : IConsumer<ServiceCreated>
    {
        private readonly IServiceService _serviceService;

        public ServiceCreatedConsumer(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task Consume(ConsumeContext<ServiceCreated> context)
        {
            var eventModel = context.Message;
            await _serviceService.CreateAsync(eventModel.Id, eventModel.Name, context.CancellationToken);
        }
    }
}
