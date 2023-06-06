using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class DoctorCreatedConsumer : IConsumer<DoctorCreated>
    {
        private readonly IDoctorService _doctorService;

        public DoctorCreatedConsumer(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task Consume(ConsumeContext<DoctorCreated> context)
        {
            var eventModel = context.Message;

            await _doctorService.CreateAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                               eventModel.LastName, context.CancellationToken);
        }
    }
}
