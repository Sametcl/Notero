using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);
            await repository.CreateAsync(blog);
            var response = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(blog);
        }
    }
}
