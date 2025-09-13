using MediatR;
using Notero.Application.Base;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notero.Application.Features.Comments.Commands
{
    public record CreateCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; init; }
        public string Body { get; init; }
        [JsonIgnore]
        public DateTime CommentDate { get; init; } = DateTime.UtcNow;   
        public Guid BlogId { get; init; }
    };
}
