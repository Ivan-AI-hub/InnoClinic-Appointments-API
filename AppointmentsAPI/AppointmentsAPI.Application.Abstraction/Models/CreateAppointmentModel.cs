namespace AppointmentsAPI.Application.Abstraction.Models
{
    public record CreateAppointmentModel(PatientDTO Patient,
                                         DoctorDTO Doctor,
                                         ServiceDTO Service,
                                         DateOnly Date,
                                         TimeOnly Time);
}
