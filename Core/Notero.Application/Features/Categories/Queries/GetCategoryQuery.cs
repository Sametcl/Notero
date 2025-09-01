using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Categories.Results;

namespace Notero.Application.Features.Categories.Queries
{
    public class GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>
    {
    }
}
