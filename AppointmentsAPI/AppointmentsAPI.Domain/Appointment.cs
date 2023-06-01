namespace AppointmentsAPI.Domain
{
    public class Appointment
    {
        private Patient? _patient;
        private Doctor? _doctor;
        private Service? _service;

        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsApproved { get; set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; private set; }

        private Appointment() { }
        public Appointment(Patient patient, Doctor doctor, Service service, DateOnly date, TimeOnly time, bool isApproved)
        {
            Patient = patient;
            Doctor = doctor;
            Service = service;
            Date = date;
            Time = time;
            IsApproved = isApproved;
        }
        public Appointment(Guid patientId, Guid doctorId, Guid serviceId, DateOnly date, TimeOnly time, bool isApproved)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceId = serviceId;
            Date = date;
            Time = time;
            IsApproved = isApproved;
        }

        public Patient? Patient
        {
            get => _patient;
            set { _patient = value; PatientId = value != null ? value.Id : PatientId; }
        }
        public Doctor? Doctor
        {
            get => _doctor;
            set { _doctor = value; DoctorId = value != null ? value.Id : DoctorId; }
        }
        public Service? Service
        {
            get => _service;
            set { _service = value; ServiceId = value != null ? value.Id : ServiceId; }
        }
    }
}