using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Notero.Application.Base;
using Notero.Application.Features.Users.Command;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler(UserManager<AppUser> userManager , IMapper mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
            };
            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }
            return BaseResult<object>.Success("User is created succeedfuly .");
        }
    }
}
