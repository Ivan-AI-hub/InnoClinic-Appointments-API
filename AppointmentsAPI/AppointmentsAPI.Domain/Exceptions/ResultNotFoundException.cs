namespace AppointmentsAPI.Domain.Exceptions
{
    public class ResultNotFoundException : NotFoundException
    {
        public ResultNotFoundException(Guid id)
            : base($"appointment result with ID = {id} does not exist")
        {
        }
        {
        }
    }
}
