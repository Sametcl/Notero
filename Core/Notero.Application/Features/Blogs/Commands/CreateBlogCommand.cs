using MediatR;
using Notero.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<BaseResult<object>>
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage { get; set; }
        public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public string UserId { get; set; }
    };
}
