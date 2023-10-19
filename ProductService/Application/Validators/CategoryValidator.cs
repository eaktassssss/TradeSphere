using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Validators
{
    using FluentValidation;
    using ProductService.Application.Contract.Request.Category;

    public class CategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters in length.");
        }
    }

}
