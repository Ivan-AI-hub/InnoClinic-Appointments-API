using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class PatientUpdatedConsumer : IConsumer<PatientUpdated>
    {
        private readonly IPatientService _patientService;

        public PatientUpdatedConsumer(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task Consume(ConsumeContext<PatientUpdated> context)
        {
            var eventModel = context.Message;

            await _patientService.UpdateAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                                eventModel.LastName, context.CancellationToken);
        }
    }
}
