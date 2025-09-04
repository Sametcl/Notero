using MediatR;
using Notero.Application.Features.Categories.Commands;
using Notero.Application.Features.Categories.Queries;

namespace Notero.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var categories = app.MapGroup("/categories").WithTags("Categories");


            categories.MapGet("", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCategoryQuery());
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(response);
            });
            categories.MapPost("", async (CreateCategoryCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest();
            });


            categories.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCategoryByIdQuery(id));
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(response);
            });

            categories.MapPut("", async (UpdateCategoryCommand command, IMediator mediator) =>
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
