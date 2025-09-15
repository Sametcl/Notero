using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.SubComments.Commands;
using Notero.Domain.Entities;

namespace Notero.Application.Features.SubComments.Handlers
{
    public class CreateSubCommentCommandHandler(IRepository<SubComment> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subcomment = mapper.Map<SubComment>(request);   
            await repository.CreateAsync(subcomment);  
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(subcomment);    
        }
    }
}
