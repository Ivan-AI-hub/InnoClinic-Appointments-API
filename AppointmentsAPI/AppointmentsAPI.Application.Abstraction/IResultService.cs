using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;

namespace AppointmentsAPI.Application.Abstraction
{
    public interface IResultService
    {
        public Task<ResultDTO> CreateResultAsync(CreateResultModel model, CancellationToken cancellationToken = default);
        public Task EditResultAsync(Guid id, EditResultModel model, CancellationToken cancellationToken = default);
        public Task<ResultDTO> GetResultByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default);
    }
}
