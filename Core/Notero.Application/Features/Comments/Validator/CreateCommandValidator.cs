using FluentValidation;
using Notero.Application.Features.Comments.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Validator
{
    public class CreateCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Comment body is required.")
                .MaximumLength(150).WithMessage("Comment body must not exceed 150 characters.");
            RuleFor(x => x.BlogId)
                .NotEmpty().WithMessage("BlogId is required.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
