using MediatR;
using Notero.Application.Base;
using Notero.Application.Features.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Users.Queries
{
    public class GetLoginQuery :IRequest<BaseResult<GetLoginQueryResult>>   
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
