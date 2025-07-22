using System;
using MediatR;

namespace SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey
{
    public class CreateSurveyCommand : IRequest<Guid> // Dönüş tipi
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

