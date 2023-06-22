using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;
namespace AppointmentsAPI.Presentation.Consumers
{
    public class DoctorUpdatedConsumer : IConsumer<DoctorUpdated>
    {
        private readonly IDoctorService _doctorService;
        public DoctorUpdatedConsumer(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task Consume(ConsumeContext<DoctorUpdated> context)
        {
            var eventModel = context.Message;

            await _doctorService.UpdateAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                               eventModel.LastName, context.CancellationToken);
        }
    }
}
