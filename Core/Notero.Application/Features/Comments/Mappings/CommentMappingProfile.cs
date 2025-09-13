using AutoMapper;
using Notero.Application.Features.Comments.Commands;
using Notero.Application.Features.Comments.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Comments.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentQueryResult>().ReverseMap();
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>().ReverseMap();
        }
    }
}
