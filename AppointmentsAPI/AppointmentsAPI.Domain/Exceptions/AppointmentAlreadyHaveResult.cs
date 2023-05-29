namespace AppointmentsAPI.Domain.Exceptions
{
    public class AppointmentAlreadyHaveResult : BadRequestException
    {
        public AppointmentAlreadyHaveResult(Guid id)
            : base("appointment with ID = {id} already has a result. You can't create a appointment result for him.")
        {
        }
    }
}
