using FluentValidation;
using Notero.Application.Features.Blogs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Validators
{
    public class CreateBlogValidator :AbstractValidator<CreateBlogCommand>  
    {
        public CreateBlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("CoverImage is required");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("BlogImage is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
