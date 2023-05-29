namespace AppointmentsAPI.Domain
{
    public class Doctor
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
