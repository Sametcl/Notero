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
    public class GetBlogsQueryHandler(IRepository<Blog> repository , IMapper mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await repository.GetAllAsync();
            var response = mapper.Map<List<GetBlogsQueryResult>>(blogs);
            return BaseResult<List<GetBlogsQueryResult>>.Success(response); 
        }
    }
}
