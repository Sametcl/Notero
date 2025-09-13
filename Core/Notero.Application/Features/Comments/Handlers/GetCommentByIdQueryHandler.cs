using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Comments.Queries;
using Notero.Application.Features.Comments.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Handlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> repository , IMapper mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment not found");
            }
            var mappedComment = mapper.Map<GetCommentByIdQueryResult>(comment);
            return BaseResult<GetCommentByIdQueryResult>.Success(mappedComment);
        }
    }
}
