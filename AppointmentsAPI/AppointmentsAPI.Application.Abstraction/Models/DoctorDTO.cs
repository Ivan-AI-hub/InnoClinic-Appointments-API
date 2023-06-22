namespace AppointmentsAPI.Application.Abstraction.Models
{
    public class DoctorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DoctorDTO() { }
        public DoctorDTO(Guid id, string firstName, string lastName, string middleName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
    }
}
