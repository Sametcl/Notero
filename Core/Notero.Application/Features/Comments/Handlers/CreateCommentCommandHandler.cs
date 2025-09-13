using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Comments.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Comments.Handlers
{
    public class CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Comment> repository) 
        : IRequestHandler<CreateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var mappedComment = mapper.Map<Comment>(request);
            await repository.CreateAsync(mappedComment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedComment);
        }
    }
}
