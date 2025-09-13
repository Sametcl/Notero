using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Comments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Queries
{
    public record GetCommentByIdQuery(Guid Id) :IRequest<BaseResult<GetCommentByIdQueryResult>>;
    
}
