using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;

namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate
{
    public class ResultDTO
    {
        public Guid Id { get; set; }
        public string Complaints { get; set; }
        public string Conclusion { get; set; }
        public string Recomendations { get; set; }
        public AppointmentDTO Appointment { get; set; }

        public ResultDTO(Guid id, string complaints, string conclusion, string recomendations, AppointmentDTO appointment)
        {
            Id = id;
            Complaints = complaints;
            Conclusion = conclusion;
            Recomendations = recomendations;
            Appointment = appointment;
        }
    }
}
