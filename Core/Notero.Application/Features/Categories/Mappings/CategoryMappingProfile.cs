using AutoMapper;
using Notero.Application.Features.Categories.Results;
using Notero.Domain.Entities;

namespace Notero.Application.Features.Categories.Mappings
{
    public class CategoryMappingProfile :Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category,GetCategoryQueryResult>().ReverseMap();
        }
    }
}
