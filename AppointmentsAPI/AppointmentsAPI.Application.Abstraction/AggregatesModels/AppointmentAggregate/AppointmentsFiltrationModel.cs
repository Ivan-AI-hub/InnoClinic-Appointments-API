namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate
{
    public record AppointmentsFiltrationModel(DateOnly Date = default,
                                              string doctorFirstName = "",
                                              string doctorMiddleName = "",
                                              string doctorLastName = "",
                                              string serviceName = "",
                                              bool status = default,
                                              Guid OfficeId = default);
}
