namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsApproved { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public ServiceDTO ServiceDTO { get; set; }

        public AppointmentDTO(Guid id, DateOnly date, TimeOnly time, bool isApproved, PatientDTO patient, DoctorDTO doctor, ServiceDTO serviceDTO)
        {
            Id = id;
            Date = date;
            Time = time;
            IsApproved = isApproved;
            Patient = patient;
            Doctor = doctor;
            ServiceDTO = serviceDTO;
        }
    }
}
