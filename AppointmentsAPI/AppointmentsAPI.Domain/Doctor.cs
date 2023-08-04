namespace AppointmentsAPI.Domain
{
    public class Doctor
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        private Doctor() { }
        public Doctor(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public Doctor(Guid id, string firstName, string lastName, string middleName) : this(firstName, lastName, middleName)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
