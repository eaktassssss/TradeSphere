using FluentValidation;
using CustomerService.Application.Contract.Request.Customer;

namespace CustomerService.Application.Validators
{
    public class CustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.")
                .Length(2, 50).WithMessage("FirstName must be between 2 and 50 characters in length.");

            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .Length(2, 50).WithMessage("LastName must be between 2 and 50 characters in length.");

            RuleFor(customer => customer.JoiningDate)
                .NotEmpty().WithMessage("JoiningDate cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("JoiningDate cannot be a future date.");


        }
    }
}
