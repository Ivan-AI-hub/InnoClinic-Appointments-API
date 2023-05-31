using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsAPI.Presentation.Controllers
{
    [ApiController]
    [Route("/results/")]
    public class ResultController : ControllerBase
    {
        private IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResultAsync(CreateResultModel model, CancellationToken cancellationToken = default)
        {
            var result = await _resultService.CreateResultAsync(model, cancellationToken);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> EditResultAsync(Guid id, EditResultModel model, CancellationToken cancellationToken = default)
        {
            await _resultService.EditResultAsync(id, model, cancellationToken);
            return Accepted();
        }

        [Route("{appointmentId}/result")]
        [HttpGet]
        public IActionResult GetResultByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default)
        {
            var result = _resultService.GetResultByAppointmentAsync(appointmentId, cancellationToken);
            return Ok(result);
        }
    }
}
