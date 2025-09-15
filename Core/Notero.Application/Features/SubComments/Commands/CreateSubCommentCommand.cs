using MediatR;
using Notero.Application.Base;
using System.Text.Json.Serialization;

namespace Notero.Application.Features.SubComments.Commands
{
    public record CreateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; init; }
        public string Body { get; init; }
        [JsonIgnore]
        public DateTime CommentDate { get; init; } = DateTime.UtcNow;
        public Guid CommentId { get; init; }
    }
}
