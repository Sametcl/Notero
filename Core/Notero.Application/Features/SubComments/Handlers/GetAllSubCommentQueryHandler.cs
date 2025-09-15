using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.SubComments.Queries;
using Notero.Application.Features.SubComments.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.SubComments.Handlers
{
    public class GetAllSubCommentQueryHandler(IRepository<SubComment> repository, IMapper mapper) : IRequestHandler<GetAllSubCommentQuery, BaseResult<List<GetAllSubCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllSubCommentQueryResult>>> Handle(GetAllSubCommentQuery request, CancellationToken cancellationToken)
        {
            var subComments = await repository.GetAllAsync();
            if (subComments == null || !subComments.Any())
            {
                return BaseResult<List<GetAllSubCommentQueryResult>>.NotFound("No subcomments found");
            }
            var mappedSubComments = mapper.Map<List<GetAllSubCommentQueryResult>>(subComments);
            return BaseResult<List<GetAllSubCommentQueryResult>>.Success(mappedSubComments);
        }
    }
}
