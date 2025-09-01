using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Categories.Queries;
using Notero.Application.Features.Categories.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Categories.Handlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _repository ,IMapper _mapper) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
    {
        public async Task<BaseResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetCategoryQueryResult>>(categories);
            return BaseResult<List<GetCategoryQueryResult>>.Success(response);
        }
    }
}
