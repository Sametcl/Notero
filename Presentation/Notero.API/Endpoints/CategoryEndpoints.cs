using MediatR;
using Notero.Application.Features.Categories.Queries;

namespace Notero.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var categories = app.MapGroup("/categories").WithTags("Categories");


            categories.MapGet("", async(IMediator mediator) =>
            {
                var response =await mediator.Send(new GetCategoryQuery());
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(response);
            });
        }
    }
}
