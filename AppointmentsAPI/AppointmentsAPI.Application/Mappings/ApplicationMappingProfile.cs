using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
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
            CreateMap<Result, ResultDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();

            CreateMap<CreateResultModel, Result>().ReverseMap();
            CreateMap<EditResultModel, Result>().ReverseMap();

            CreateMap<CreateAppointmentModel, Appointment>().ReverseMap();
            CreateMap<AppointmentsFiltrationModel, AppointmentFiltrator>();
        }
    }
}
