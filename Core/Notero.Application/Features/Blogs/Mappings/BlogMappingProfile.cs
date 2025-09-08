using AutoMapper;
using Notero.Application.Features.Blogs.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile :Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
        }
    }
}
