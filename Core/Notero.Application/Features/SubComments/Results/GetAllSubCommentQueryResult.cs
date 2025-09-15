using Notero.Application.Base;
using Notero.Application.Features.Comments.Results;
using Notero.Application.Features.Users.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.SubComments.Results
{
    public class GetAllSubCommentQueryResult : BaseDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public  GetUsersQueryResult User { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public  GetCommentQueryResult Comment { get; set; }
    }
}
