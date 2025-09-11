using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Blogs.Handlers
{
    public class DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IRepository<Blog> repository) : IRequestHandler<DeleteBlogCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return BaseResult<bool>.NotFound("Blog not found");
            }   
            repository.Delete(result);
            var response = await unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Failed to delete blog");
        }
    }
}
