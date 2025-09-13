using Notero.Application.Base;
using Notero.Application.Features.Blogs.Results;
using Notero.Application.Features.Users.Results;

namespace Notero.Application.Features.Comments.Results
{
    public class GetCommentQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid BlogId { get; set; }
        public GetBlogsQueryResult Blog { get; set; }
        //public IList<SubComment> SubComments { get; set; }
    }
}
