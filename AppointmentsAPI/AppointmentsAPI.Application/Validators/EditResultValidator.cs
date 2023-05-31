using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
using FluentValidation;

namespace AppointmentsAPI.Application.Validators
{
    public class EditResultValidator : AbstractValidator<EditResultModel>
    {
        public EditResultValidator()
        {
            RuleFor(x => x.Complaints).NotEmpty().NotNull();
            RuleFor(x => x.Conclusion).NotEmpty().NotNull();
            RuleFor(x => x.Recomendations).NotEmpty().NotNull();
        }
    }
}
