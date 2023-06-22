using AppointmentsAPI.Application.Abstraction;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Presentation.Consumers
{
    public class PatientDeletedConsumer : IConsumer<PatientDeleted>
    {
        private readonly IPatientService _patientService;

        public PatientDeletedConsumer(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task Consume(ConsumeContext<PatientDeleted> context)
        {
            var eventModel = context.Message;

            await _patientService.DeleteAsync(eventModel.Id, context.CancellationToken);
        }
    }
}
