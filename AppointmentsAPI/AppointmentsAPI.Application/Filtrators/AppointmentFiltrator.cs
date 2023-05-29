using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;
using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Interfaces;

namespace AppointmentsAPI.Application.Filtrators
{
    internal class AppointmentFiltrator : AppointmentsFiltrationModel, IFiltrator<Appointment>
    {
        public IQueryable<Appointment> Filtrate(IQueryable<Appointment> query)
        {
            query = Date != default ? query.Where(x => x.Date == Date) : query;
            query = DoctorFirstName != "" ? query.Where(x => x.Doctor.FirstName == DoctorFirstName) : query;
            query = DoctorMiddleName != "" ? query.Where(x => x.Doctor.MiddleName == DoctorMiddleName) : query;
            query = DoctorLastName != "" ? query.Where(x => x.Doctor.LastName == DoctorLastName) : query;
            query = ServiceName != "" ? query.Where(x => x.Service.Name == ServiceName) : query;
            query = Status != default ? query.Where(x => x.IsApproved == Status) : query;

            return query;
        }
    }
}
