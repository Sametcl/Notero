using Notero.Application.Features.Users.Results;

namespace Notero.Application.Contracts.Persistance
{
    public interface IJwtService
    {
        Task<GetLoginResponse> GenerateTokenAsync(GetUsersQueryResult result);
    }
    
}
