using System;
using MediatR;

namespace SurveyManagement.Application.Features.Surveys.Commands.UpdateSurvey
{
	public class UpdateSurveyCommand : IRequest<Guid>
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

