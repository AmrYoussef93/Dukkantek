using Dukkantek.Services.DTOs;
using FluentValidation;

namespace Dukkantek.API.Common.Validations
{
    public class OrderProductValidator : AbstractValidator<OrderProductDTO>
    {
        public OrderProductValidator()
        {
            RuleFor(i => i.ProductId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product Id is required!");

            RuleFor(i => i.Quantity)
                .NotNull()
                .NotEmpty()
                .WithMessage("Quantity is required!")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0!");
        }
    }
}
