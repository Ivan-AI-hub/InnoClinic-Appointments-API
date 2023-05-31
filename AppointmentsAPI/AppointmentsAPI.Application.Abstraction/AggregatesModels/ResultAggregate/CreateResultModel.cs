namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate
{
    public class CreateResultModel
    {
        public string Complaints { get; set; }
        public string Conclusion { get; set; }
        public string Recomendations { get; set; }
        public Guid AppointmentId { get; set; }

        public CreateResultModel(string complaints, string conclusion, string recomendations, Guid appointmentId)
        {
            Complaints = complaints;
            Conclusion = conclusion;
            Recomendations = recomendations;
            AppointmentId = appointmentId;
        }
    }
}
