using MediatR;
using Notero.Application.Features.Comments.Commands;
using Notero.Application.Features.Comments.Queries;

namespace Notero.API.Endpoints
{
    public static class CommentEndpoints
    {
        public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("comments").WithTags("Comments");

            comments.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCommentQuery());
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(response);
            });

            comments.MapPost(string.Empty, async (IMediator mediator, CreateCommentCommand command) =>
            {
                var response = await mediator.Send(command);
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(response);
            });
        }
    }
}
