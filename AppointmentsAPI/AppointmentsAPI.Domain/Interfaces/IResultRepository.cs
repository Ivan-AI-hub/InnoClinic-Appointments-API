namespace AppointmentsAPI.Domain.Interfaces
{
    public interface IResultRepository
    {
        /// <summary>
        /// Adds result in database
        /// </summary>
        /// <returns>Added result</returns>
        public Task AddAsync(Result result, CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates result in database
        /// </summary>
        public Task UpdateAsync(Guid id, string complaints, string conclusion,
                                      string recomendations, CancellationToken cancellationToken = default);

        /// <returns>Result for appointment with ID = <paramref name="appointmentId"/></returns>
        public Task<Result> GetByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default);
    }
}
