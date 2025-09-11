using AutoMapper;
using Notero.Application.Features.Blogs.Commands;
using Notero.Application.Features.Blogs.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile :Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByCategoryIdQueryResult>().ReverseMap();
        }
    }
}
