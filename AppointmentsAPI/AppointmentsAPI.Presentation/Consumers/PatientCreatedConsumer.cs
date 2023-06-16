using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class PatientCreatedConsumer : IConsumer<PatientCreated>
    {
        private readonly IPatientService _patientService;

        public PatientCreatedConsumer(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task Consume(ConsumeContext<PatientCreated> context)
        {
            var eventModel = context.Message;

            await _patientService.CreateAsync(eventModel.Id, eventModel.FirstName, eventModel.MiddleName,
                                                eventModel.LastName, context.CancellationToken);
        }
    }
}
