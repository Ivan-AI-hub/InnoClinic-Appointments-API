namespace AppointmentsAPI.Domain.Exceptions
{
    public class AppointmentAlreadyApproved : BadRequestException
    {
        public AppointmentAlreadyApproved(Guid id)
            : base($"Appointment with ID = {id} has already been approved and can't be rescheduled")
        {
        }
    }
}
