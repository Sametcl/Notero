using MediatR;
using Notero.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Commands
{
    public record DeleteCommentCommand(Guid Id) : IRequest<BaseResult<object>>;
}
