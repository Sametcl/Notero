using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Features.Users.Results;
using Notero.Application.Options;
using Notero.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Notero.Persistance.Concrete
{
    public class JwtService(UserManager<AppUser> userManager , IOptions<JwtTokenOptions> tokenOptions) : IJwtService
    {
        private readonly JwtTokenOptions jwtTokenOptions = tokenOptions.Value;
        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
        {
            var user = await userManager.FindByNameAsync(result.UserName);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtTokenOptions.Key));
            var dateTimeNow = DateTime.UtcNow;

            List<Claim> claims = new()
            {
                //new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                // new(ClaimTypes.Name, user.UserName), Identity otomatik dolduruyor
                new(JwtRegisteredClaimNames.Name, user.UserName),
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new("FullName", $"{user.FirstName} {user.LastName}")
            };

            JwtSecurityToken jwtSecurityToken = new
                (
                    issuer: jwtTokenOptions.Issuer,
                    audience: jwtTokenOptions.Audience,
                    claims: claims,
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.AddMinutes(jwtTokenOptions.ExpireInMinutes),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            GetLoginQueryResult response = new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpirationTime = dateTimeNow.AddMinutes(jwtTokenOptions.ExpireInMinutes)
            };

            return response;
        }
    }
}
