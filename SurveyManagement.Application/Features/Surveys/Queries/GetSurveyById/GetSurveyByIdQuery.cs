using System;
using MediatR;
using SurveyManagement.Application.DTOs;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetSurveyById
{
    public class GetSurveyByIdQuery : IRequest<SurveyDto>
    {
        public Guid Id { get; set; }

        public GetSurveyByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

