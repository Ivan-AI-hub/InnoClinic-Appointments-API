namespace AppointmentsAPI.Domain
{
    public class Result
    {
        private Appointment? _appointment;

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Complaints { get; set; }
        public string Conclusion { get; set; }
        public string Recomendations { get; set; }

        public Guid AppointmentId { get; private set; }

        private Result() { }

        public Result(string complaints, string conclusion, string recomendations, Appointment appointment)
        {
            Complaints = complaints;
            Conclusion = conclusion;
            Recomendations = recomendations;
            Appointment = appointment;
        }
        public Result(string complaints, string conclusion, string recomendations, Guid appointmentId)
        {
            Complaints = complaints;
            Conclusion = conclusion;
            Recomendations = recomendations;
            AppointmentId = appointmentId;
        }

        public Appointment? Appointment
        {
            get => _appointment;
            set { _appointment = value; AppointmentId = value != null ? value.Id : AppointmentId; }
        }
    }
}
