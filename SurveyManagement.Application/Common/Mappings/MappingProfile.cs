using System;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Domain.Entities;
using AutoMapper;

namespace SurveyManagement.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Survey, SurveyDto>().ReverseMap();
        }
    }
}

