namespace AppointmentsAPI.Application.Abstraction.Models
{
    public record CreateAppointmentModel(Guid PatientId,
                                         Guid DoctorId,
                                         Guid ServiceId,
                                         DateOnly Date,
                                         TimeOnly Time);
}
