using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Queries;
using Notero.Application.Features.Blogs.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Blogs.Handlers
{
    public class GetBlogByCategoryIdQueryHandler(IRepository<Blog> repository , IMapper mapper) : IRequestHandler<GetBlogByCategoryIdQuery, BaseResult<List<GetBlogByCategoryIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogByCategoryIdQueryResult>>> Handle(GetBlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = repository.GetQuery().Where(b => b.CategoryId == request.CategoryId).ToList();
            if (blogs == null || blogs.Count == 0)
            {
                return BaseResult<List<GetBlogByCategoryIdQueryResult>>.NotFound("No blogs found for the given category");
            }
            var mappedBlogs = mapper.Map<List<GetBlogByCategoryIdQueryResult>>(blogs);  
            return BaseResult<List<GetBlogByCategoryIdQueryResult>>.Success(mappedBlogs);

        }
    }
}
