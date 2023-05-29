﻿namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate
{
    public class DoctorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DoctorDTO(Guid id, string firstName, string lastName, string middleName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
    }
}