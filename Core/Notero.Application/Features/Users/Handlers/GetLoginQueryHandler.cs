using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Notero.Application.Base;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Users.Queries;
using Notero.Application.Features.Users.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Users.Handlers
{
    public class GetLoginQueryHandler(UserManager<AppUser> userManager, IJwtService jwtService, IMapper mapper)
        : IRequestHandler<GetLoginQuery, BaseResult<GetLoginQueryResult>>
    {
        public async Task<BaseResult<GetLoginQueryResult>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BaseResult<GetLoginQueryResult>.NotFound("user not found");
            }
            var checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
            if (!checkPassword)
            {
                return BaseResult<GetLoginQueryResult>.Fail("email or password is incorrect");
            }

            var response = await jwtService.GenerateTokenAsync(mapper.Map<GetUsersQueryResult>(user));
            if (response == null)
            {
                return BaseResult<GetLoginQueryResult>.Fail("token generation failed");
            }
            return BaseResult<GetLoginQueryResult>.Success(response);
        }
    }
}
