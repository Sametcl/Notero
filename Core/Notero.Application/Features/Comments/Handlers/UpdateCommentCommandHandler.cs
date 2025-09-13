using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Comments.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Comments.Handlers
{
    public class UpdateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<object>.NotFound("Comment not found");
            }
            mapper.Map(request, comment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Comment has been updated successfully");
        }
    }
}
