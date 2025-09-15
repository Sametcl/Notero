using FluentValidation;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.SubComments.Validators
{
    public class CreateSubCommentValidator: AbstractValidator<SubComment>
    {
        public CreateSubCommentValidator()
        {
            RuleFor(x=> x.Body)
                .NotEmpty().WithMessage("Body is required")
                .MaximumLength(100).WithMessage("Body must not exceed 1000 characters");   
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId is required");
        }
    }
}
