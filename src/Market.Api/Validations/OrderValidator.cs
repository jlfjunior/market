using FluentValidation;
using Market.Api.Models;

namespace Market.Api.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CreatedAt).NotNull();
            RuleFor(x => x.Items).NotNull().NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }
    }

    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Amount).NotNull();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.Description).NotNull().MinimumLength(10).MaximumLength(100);
        }
    }
}
