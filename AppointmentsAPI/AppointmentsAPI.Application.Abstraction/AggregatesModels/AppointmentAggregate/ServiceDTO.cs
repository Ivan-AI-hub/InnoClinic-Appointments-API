namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ServiceDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
