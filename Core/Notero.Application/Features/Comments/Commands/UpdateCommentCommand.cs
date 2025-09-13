using MediatR;
using Notero.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string UserId { get; init; }
        public string Body { get; init; }
        public Guid BlogId { get; init; }
    };
}
