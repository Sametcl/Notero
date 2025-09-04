using MediatR;
using Notero.Application.Base;

namespace Notero.Application.Features.Categories.Commands
{
    public record UpdateCategoryCommand(Guid Id, string categoryName) : IRequest<BaseResult<bool>>;
}
