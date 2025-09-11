using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Commands;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IRepository<Blog> repository, IMapper mapper) 
        : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<object>.NotFound("Blog not found");
            }
            mapper.Map(request, blog);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog has been updated successfully");
        }
    }
}
