using FluentValidation;
using Notero.Application.Features.Categories.Commands;

namespace Notero.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator :AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.categoryName)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MinimumLength(3)
                .WithMessage("Category Name must be at least 3 characters");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Category Id is required");
        }
    }
}
