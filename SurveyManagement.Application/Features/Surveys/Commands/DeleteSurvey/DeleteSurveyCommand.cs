using System;
using MediatR;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Features.Surveys.Commands.DeleteSurvey
{
	public class DeleteSurveyCommand :IRequest<SurveyResult<bool>>
	{
		public Guid Id { get; set; }

        public DeleteSurveyCommand(Guid id)
        {
            Id = id;
        }
    }
}

