using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Categories.Queries;
using Notero.Application.Features.Categories.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.Id);  
            if (category == null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound($"Category with id {request.Id} not found.");
            }

            var response = mapper.Map<GetCategoryByIdQueryResult>(category);
            return BaseResult<GetCategoryByIdQueryResult>.Success(response);
        }
    }
}
