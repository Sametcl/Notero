using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Categories.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Categories.Handlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> repository,IUnitOfWork unitOfWork,IMapper mapper) 
        : IRequestHandler<CreateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            await repository.CreateAsync(category);
            var result= await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail("Failed to create category");
        }
    }
}
