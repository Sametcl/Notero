using FluentValidation;
using Notero.Application.Base;

namespace Notero.API.CustomMiddlewares
{
    public class CustomExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var errorResponse = new BaseResult<object>()
                {
                    Errors = ex.Errors.GroupBy(e => e.PropertyName)
                    .Select(g => new Error()
                    {
                        PropertyName = g.Key,
                        ErrorMessage = g.Select(e => e.ErrorMessage).FirstOrDefault()
                    }).ToList()
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
               
                await context.Response.WriteAsJsonAsync(new {errorMessage =ex.Message});
            }
        }
    }
}
