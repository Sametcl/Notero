using AutoMapper;
using MediatR;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Blogs.Commands;
using Notero.Application.Features.Comments.Commands;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Handlers
{
    public class DeleteCommentCommandHandler(IRepository<Comment> repository, IMapper mapper , IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return BaseResult<object>.NotFound("Blog not found");
            }
            repository.Delete(result);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Comment deleted");
        }
    }
}
