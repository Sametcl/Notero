using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Blogs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Queries
{
    public record GetBlogByCategoryIdQuery(Guid CategoryId) 
        : IRequest<BaseResult<List<GetBlogByCategoryIdQueryResult>>>;
}
