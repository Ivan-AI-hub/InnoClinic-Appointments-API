using AppointmentsAPI.Application.Abstraction.Models;
using FluentValidation;

namespace AppointmentsAPI.Application.Validators
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentModel>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.Patient).NotNull();
            RuleFor(x => x.Doctor).NotNull();
            RuleFor(x => x.Service).NotNull();
            RuleFor(x => x.Date).NotEmpty().NotNull();
            RuleFor(x => x.Time).NotEmpty().NotNull();
        }
    }
}
