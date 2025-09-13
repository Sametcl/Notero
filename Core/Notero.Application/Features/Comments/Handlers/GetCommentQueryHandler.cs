using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Comments.Queries;
using Notero.Application.Features.Comments.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Comments.Handlers
{
    public class GetCommentQueryHandler(IRepository<Comment> repository, IMapper mapper) : IRequestHandler<GetCommentQuery, BaseResult<List<GetCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentQueryResult>>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            if (values == null || !values.Any())
            {
                return BaseResult<List<GetCommentQueryResult>>.NotFound("No comments found.");
            }
            var mappedComments = mapper.Map<List<GetCommentQueryResult>>(values);
            return BaseResult<List<GetCommentQueryResult>>.Success(mappedComments);
        }
    }
}
