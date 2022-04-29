using Dukkantek.Services.DTOs;
using FluentValidation;

namespace Dukkantek.API.Common.Validations
{
    public class ChangeProductStatusValidator : AbstractValidator<ChangeProductStatusDTO>
    {
        public ChangeProductStatusValidator()
        {
            RuleFor(c => c.Status)
                .NotNull()
                .WithMessage("Status is required!");

        }
    }
}
