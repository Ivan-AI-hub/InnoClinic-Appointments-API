using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class PatientNameUpdatedConsumer : IConsumer<PatientNameUpdated>
    {
        private readonly IPatientService _patientService;

        public PatientNameUpdatedConsumer(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task Consume(ConsumeContext<PatientNameUpdated> context)
        {
            var eventModel = context.Message;

            await _patientService.UpdateFullNameAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                                eventModel.LastName, context.CancellationToken);
        }
    }
}
