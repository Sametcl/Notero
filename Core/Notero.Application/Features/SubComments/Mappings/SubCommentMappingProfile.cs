using AutoMapper;
using FluentValidation;
using Notero.Application.Features.SubComments.Commands;
using Notero.Application.Features.SubComments.Queries;
using Notero.Application.Features.SubComments.Results;
using Notero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.SubComments.Mappings
{
    public class SubCommentMappingProfile :Profile
    {
        public SubCommentMappingProfile()
        {
            CreateMap<SubComment,CreateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment,GetAllSubCommentQueryResult>().ReverseMap();
        }
    }
}
