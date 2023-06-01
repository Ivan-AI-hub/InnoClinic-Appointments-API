using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class ServiceNameUpdatedConsumer : IConsumer<ServiceNameUpdated>
    {
        private readonly IServiceService _serviceService;

        public ServiceNameUpdatedConsumer(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task Consume(ConsumeContext<ServiceNameUpdated> context)
        {
            var eventModel = context.Message;
            await _serviceService.UpdateNameAsync(eventModel.Id, eventModel.Name, context.CancellationToken);
        }
    }
}
