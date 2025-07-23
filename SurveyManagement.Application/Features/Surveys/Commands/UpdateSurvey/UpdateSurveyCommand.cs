using System;
using MediatR;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Features.Surveys.Commands.UpdateSurvey
{
	public class UpdateSurveyCommand : IRequest<SurveyResult<Guid>>
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

