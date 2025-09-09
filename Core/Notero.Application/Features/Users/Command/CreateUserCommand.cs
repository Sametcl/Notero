using MediatR;
using Notero.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Users.Command
{
    public record CreateUserCommand (string FirstName , string LastName, string Email, string UserName,string Password) : IRequest<BaseResult<object>>;   
}
