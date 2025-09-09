using MediatR;
using Notero.Application.Features.Users.Command;

namespace Notero.API.Endpoints
{
    public static class UserEndpoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users");


            users.MapPost("register", async (IMediator mediator ,CreateUserCommand command) =>
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
