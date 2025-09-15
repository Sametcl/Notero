using MediatR;
using Notero.Application.Features.SubComments.Commands;

namespace Notero.API.Endpoints
{
    public static class SubCommentEndpoints
    {
        public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComments = app.MapGroup("/subcomments").WithTags("SubComments");

            subComments.MapPost(string.Empty, async (CreateSubCommentCommand command,IMediator mediator) => 
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
