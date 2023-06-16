using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.Models;
using AppointmentsAPI.Presentation.Models.ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsAPI.Presentation.Controllers
{
    [ApiController]
    [Route("/appointments/")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AppointmentDTO), 201)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> Create(CreateAppointmentModel createModel, CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentService.AddAppointmentAsync(createModel, cancellationToken);
            return CreatedAtAction(nameof(GetAppointments),
                                   new { pageSize = 1, pageNumber = 1, createModel.DoctorId, createModel.PatientId, createModel.Date },
                                   appointment);
        }

        [HttpPut("{id}/approve")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> ApproveAppointment(Guid id, CancellationToken cancellationToken = default)
        {
            await _appointmentService.ApproveAppointmentAsync(id, cancellationToken);
            return NoContent();
        }

        [HttpGet("{pageSize}/{pageNumber}")]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetAppointments(int pageSize, int pageNumber,
            [FromQuery] AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(pageSize, pageNumber, filtrationModel, cancellationToken);
            return Ok(appointments);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CancelAppointment(Guid id, CancellationToken cancellationToken = default)
        {
            await _appointmentService.CancelAppointmentAsync(id, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id}/reschedule")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> RescheduleAppointment([FromRoute] Guid id, Guid doctorId,
            DateOnly date, TimeOnly time, CancellationToken cancellationToken = default)
        {
            await _appointmentService.RescheduleAppointmentAsync(id, doctorId, date, time, cancellationToken);
            return NoContent();
        }
    }
}
