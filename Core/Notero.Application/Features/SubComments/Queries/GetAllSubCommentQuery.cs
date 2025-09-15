using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.SubComments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.SubComments.Queries
{
    public record GetAllSubCommentQuery :IRequest<BaseResult<List<GetAllSubCommentQueryResult>>>     
    {
    }
}
