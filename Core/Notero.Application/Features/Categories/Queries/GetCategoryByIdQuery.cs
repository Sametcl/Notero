using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Categories.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Categories.Queries
{
    public record GetCategoryByIdQuery(Guid Id):IRequest<BaseResult<GetCategoryByIdQueryResult>>;
    
}
