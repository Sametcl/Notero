using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Categories.Commands;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Categories.Handlers
{
    public class DeleteCategoryCommandHandler(IRepository<Category> repository ,IUnitOfWork unitOfWork ) : IRequestHandler<DeleteCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.Id);  
            if (category == null)
            {
                return BaseResult<bool>.NotFound("Category not found");
            }
            repository.Delete(category);
            var response = await unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Failed to delete category");
        }
    }
}
