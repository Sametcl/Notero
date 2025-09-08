using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Blogs.Results;

namespace Notero.Application.Features.Blogs.Queries
{
    public record GetBlogsQuery : IRequest<BaseResult<List<GetBlogsQueryResult>>>;
}
