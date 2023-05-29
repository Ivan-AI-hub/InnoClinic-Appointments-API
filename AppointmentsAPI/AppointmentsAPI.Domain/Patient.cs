namespace AppointmentsAPI.Domain
{
    public class Patient
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
