using AppointmentsAPI.Application.Abstraction.Models;
using FluentValidation;

namespace AppointmentsAPI.Application.Validators
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentModel>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.PatientId).NotNull();
            RuleFor(x => x.DoctorId).NotNull();
            RuleFor(x => x.ServiceId).NotNull();
            RuleFor(x => x.Date).NotEmpty().NotNull();
            RuleFor(x => x.Time).NotEmpty().NotNull();
        }
    }
}
