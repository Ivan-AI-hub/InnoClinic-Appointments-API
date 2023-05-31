namespace AppointmentsAPI.Domain.Exceptions
{
    public class ResultForAppointmentNotFoundException : NotFoundException
    {
        public ResultForAppointmentNotFoundException(Guid appointmentId)
            : base($"appointment result for appointment ID = {appointmentId} does not exist")
        {
        }
    }
}
