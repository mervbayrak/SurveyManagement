using System;
using MediatR;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetSurveyById
{
    public class GetSurveyByIdQuery : IRequest<SurveyResult<SurveyDto>>
    {
        public Guid Id { get; set; }

        public GetSurveyByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

