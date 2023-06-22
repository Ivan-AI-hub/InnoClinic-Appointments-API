namespace AppointmentsAPI.Domain.Exceptions
{
    public class AppointmentNotFoundException : NotFoundException
    {
        public AppointmentNotFoundException(Guid id)
            : base($"Appointment with ID = {id} does not exist")
        {
        }
    }
}
