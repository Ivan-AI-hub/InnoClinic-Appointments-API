using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;

namespace AppointmentsAPI.Application.Abstraction
{
    public interface IResultService
    {
        /// <summary>
        /// Adds result in database
        /// </summary>
        /// <returns>Added result</returns>
        public Task<ResultDTO> AddResultAsync(CreateResultModel model, CancellationToken cancellationToken = default);
        /// <summary>
        /// Edits result in database
        /// </summary>
        public Task EditResultAsync(Guid id, EditResultModel model, CancellationToken cancellationToken = default);
        /// <returns>Result for appointment with ID = <paramref name="appointmentId"/></returns>
        public Task<ResultDTO> GetResultByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default);
    }
}
