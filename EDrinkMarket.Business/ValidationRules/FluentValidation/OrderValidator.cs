using EDrinkMarket.Entity.Concrete;
using FluentValidation;

namespace EDrinkMarket.Business.ValidationRules.FluentValidation
{
    public class OrderValidator:AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty().WithMessage("Please enter your firstname");
            RuleFor(o => o.FirstName).MaximumLength(20);

            RuleFor(o => o.LastName).NotEmpty().WithMessage("Please enter your lastname");
            RuleFor(o => o.LastName).MaximumLength(20);

            RuleFor(o => o.AddressLine1).NotEmpty().WithMessage("Please enter your address");
            RuleFor(o => o.AddressLine1).MaximumLength(100);

            RuleFor(o => o.ZipCode).NotEmpty().WithMessage("Please enter your zipcode");
            RuleFor(o => o.ZipCode).MaximumLength(10);
            RuleFor(o => o.ZipCode).MinimumLength(4);

            RuleFor(o => o.State).MaximumLength(10);

            RuleFor(o => o.Country).NotEmpty().WithMessage("Please enter your country");
            RuleFor(o => o.Country).MaximumLength(20);

            RuleFor(o => o.PhoneNumber).NotEmpty().WithMessage("Please enter your phone number");
            RuleFor(o => o.PhoneNumber).MaximumLength(20);
            RuleFor(o => o.PhoneNumber).Matches(@"^\+[1-9]{1}[0-9]{7,14}$").WithMessage("Please enter valid phone number");

            RuleFor(o => o.Email).NotEmpty().WithMessage("Please enter your e-mail");
            RuleFor(o => o.Email).EmailAddress().WithMessage("Please enter valid e-mail address");




        }
    }
}
