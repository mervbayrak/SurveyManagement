using System;
using MediatR;

namespace SurveyManagement.Application.Features.Surveys.Commands.DeleteSurvey
{
	public class DeleteSurveyCommand :IRequest<bool>
	{
		public Guid Id { get; set; }

        public DeleteSurveyCommand(Guid id)
        {
            Id = id;
        }
    }
}

