namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate
{
    public record CreateAppointmentModel(PatientDTO Patient,
                                         DoctorDTO Doctor,
                                         ServiceDTO Service,
                                         DateOnly Date,
                                         TimeOnly Time);
}
