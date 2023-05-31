using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
using AppointmentsAPI.Presentation.Models.ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsAPI.Presentation.Controllers
{
    [ApiController]
    [Route("/results/")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultDTO), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CreateResultAsync(CreateResultModel model, CancellationToken cancellationToken = default)
        {
            var result = await _resultService.AddResultAsync(model, cancellationToken);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(202)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> EditResultAsync(Guid id, EditResultModel model, CancellationToken cancellationToken = default)
        {
            await _resultService.EditResultAsync(id, model, cancellationToken);
            return Accepted();
        }

        [Route("{appointmentId}/result")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultDTO), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetResultByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default)
        {
            var result = await _resultService.GetResultByAppointmentAsync(appointmentId, cancellationToken);
            return Ok(result);
        }
    }
}
