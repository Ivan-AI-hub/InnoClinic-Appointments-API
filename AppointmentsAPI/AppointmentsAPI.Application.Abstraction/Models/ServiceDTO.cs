﻿namespace AppointmentsAPI.Application.Abstraction.Models
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ServiceDTO() { }
        public ServiceDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
