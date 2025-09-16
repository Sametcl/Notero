using Notero.Application.Features.Users.Results;

namespace Notero.Application.Contracts.Persistance
{
    public interface IJwtService
    {
        Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
    }
    
}
