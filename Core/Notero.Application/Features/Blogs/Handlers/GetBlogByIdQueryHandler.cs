using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Queries;
using Notero.Application.Features.Blogs.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IMapper mapper , IRepository<Blog> repository) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog =await repository. GetByIdAsync(request.Id);   
            if (blog == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog not found");
            }
            var mappedBlog = mapper.Map<GetBlogByIdQueryResult>(blog);  
            return BaseResult<GetBlogByIdQueryResult>.Success(mappedBlog);
        }
    }
}
