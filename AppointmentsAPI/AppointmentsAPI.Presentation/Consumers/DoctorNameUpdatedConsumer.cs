using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;
namespace AppointmentsAPI.Presentation.Consumers
{
    public class DoctorNameUpdatedConsumer : IConsumer<DoctorNameUpdated>
    {
        private readonly IDoctorService _doctorService;
        public DoctorNameUpdatedConsumer(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task Consume(ConsumeContext<DoctorNameUpdated> context)
        {
            var eventModel = context.Message;

            await _doctorService.UpdateFullNameAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                               eventModel.LastName, context.CancellationToken);
        }
    }
}
