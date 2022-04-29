using Dukkantek.Services.DTOs;
using FluentValidation;

namespace Dukkantek.API.Common.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Products).Must(x => x.Count > 0).WithMessage("Please add at least one product!");

            RuleForEach(c => c.Products).SetValidator(new OrderProductValidator());
        }
    }
}
