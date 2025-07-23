using System;
using MediatR;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey
{
    public class CreateSurveyCommand : IRequest<SurveyResult<Guid>> 
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

