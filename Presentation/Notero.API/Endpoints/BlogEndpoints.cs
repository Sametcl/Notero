using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notero.Application.Features.Blogs.Commands;
using Notero.Application.Features.Blogs.Queries;

namespace Notero.API.Endpoints
{
    public static class BlogEndpoints
    {
        public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
        {
            var blogs = app.MapGroup("/blogs").WithTags("Blogs");
            blogs.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetBlogsQuery());
                if (response.IsSuccess)
                {
                    return Results.Ok(response); 
                }
                return Results.BadRequest(response);
            });

            blogs.MapPost(string.Empty, async (IMediator mediator, CreateBlogCommand command) =>
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
