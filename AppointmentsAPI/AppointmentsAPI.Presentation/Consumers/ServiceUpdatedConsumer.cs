using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdated>
    {
        private readonly IServiceService _serviceService;

        public ServiceUpdatedConsumer(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task Consume(ConsumeContext<ServiceUpdated> context)
        {
            var eventModel = context.Message;
            await _serviceService.UpdateAsync(eventModel.Id, eventModel.Name, context.CancellationToken);
        }
    }
}
