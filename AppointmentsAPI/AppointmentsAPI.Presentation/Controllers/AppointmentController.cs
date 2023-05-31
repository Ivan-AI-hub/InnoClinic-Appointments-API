﻿using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsAPI.Presentation.Controllers
{
    [ApiController]
    [Route("/appointments/")]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentModel createModel, CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentService.AddAppointmentAsync(createModel, cancellationToken);
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ApproveAppointment(Guid id, CancellationToken cancellationToken = default)
        {
            await _appointmentService.ApproveAppointmentAsync(id, cancellationToken);
            return Accepted();
        }

        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<IActionResult> GetAppointments(int pageSize, int pageNumber,
            [FromQuery] AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(pageSize, pageNumber, filtrationModel, cancellationToken);
            return Ok(appointments);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelAppointment(Guid id, CancellationToken cancellationToken = default)
        {
            await _appointmentService.CancelAppointmentAsync(id, cancellationToken);
            return Accepted();
        }

        [HttpPut("{id}/{date}/{time}/reschedule")]
        public async Task<IActionResult> RescheduleAppointment([FromRoute] Guid id, [FromBody] DoctorDTO doctor,
            [FromRoute] DateOnly date, [FromRoute] TimeOnly time, CancellationToken cancellationToken = default)
        {
            await _appointmentService.RescheduleAppointmentAsync(id, doctor, date, time, cancellationToken);
            return Accepted();
        }
    }
}
