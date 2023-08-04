namespace AppointmentsAPI.Domain
{
    public class Service
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        private Service() { }
        public Service(string name)
        {
            Name = name;
        }
        public Service(Guid id, string name) : this(name)
        {
            Id = id;
        }
    }
}
