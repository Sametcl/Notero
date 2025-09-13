using AutoMapper;
using Notero.Application.Features.Users.Command;
using Notero.Application.Features.Users.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Users.Mappings
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
            CreateMap<AppUser, GetUsersQueryResult>().ReverseMap();
        }
    }
}
