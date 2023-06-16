using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class DoctorDeletedConsumer : IConsumer<DoctorDeleted>
    {
        private readonly IDoctorService _doctorService;

        public DoctorDeletedConsumer(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task Consume(ConsumeContext<DoctorDeleted> context)
        {
            var eventModel = context.Message;

            await _doctorService.DeleteAsync(eventModel.Id, context.CancellationToken);
        }
    }
}
