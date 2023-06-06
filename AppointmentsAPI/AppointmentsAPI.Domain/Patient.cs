namespace AppointmentsAPI.Domain
{
    public class Patient
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        private Patient() { }
        public Patient(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
