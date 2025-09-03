using Notero.Persistance.Extensions;
using Notero.Application.Extensions;
using Notero.API.Endpoints.Registration;
using Scalar.AspNetCore;
using Notero.API.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// endpoint 
app.MapGroup("/api")
    .RegisterEndpoints();

app.Run();
