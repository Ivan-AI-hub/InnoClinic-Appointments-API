using AppointmentsAPI.Application.Abstraction.Models;
using AppointmentsAPI.Application.Filtrators;
using AppointmentsAPI.Domain;
using AutoMapper;

namespace AppointmentsAPI.Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();

            CreateMap<CreateAppointmentModel, Appointment>().ReverseMap();
            CreateMap<AppointmentsFiltrationModel, AppointmentFiltrator>();
        }
    }
}
