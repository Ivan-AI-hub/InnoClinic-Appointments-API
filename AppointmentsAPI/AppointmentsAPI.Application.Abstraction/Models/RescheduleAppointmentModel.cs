namespace AppointmentsAPI.Application.Abstraction.Models
{
    public record RescheduleAppointmentModel(Guid DoctorId, DateOnly Date, TimeOnly Time);
}
