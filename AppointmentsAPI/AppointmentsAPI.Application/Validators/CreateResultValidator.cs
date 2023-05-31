using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
using FluentValidation;

namespace AppointmentsAPI.Application.Validators
{
    public class CreateResultValidator : AbstractValidator<CreateResultModel>
    {
        public CreateResultValidator()
        {
            RuleFor(x => x.Complaints).NotEmpty().NotNull();
            RuleFor(x => x.Conclusion).NotEmpty().NotNull();
            RuleFor(x => x.Recomendations).NotEmpty().NotNull();
            RuleFor(x => x.AppointmentId).NotEmpty().NotNull();
        }
    }
}
