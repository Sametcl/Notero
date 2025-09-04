using AutoMapper;
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
    public class UpdateCategoryCommandHandler(IMapper mapper, IRepository<Category> repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            repository.Update(category);
            var response = await unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail("Failed to update category");
        }
    }
}
