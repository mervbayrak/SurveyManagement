using System;
using SurveyManagement.Application.Common.Validation;

namespace SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey
{
    public class CreateSurveyCommandValidator : BaseValidator<CreateSurveyCommand>
    {
        public CreateSurveyCommandValidator()
        {
            RuleFor(x => x.Title).TitleRule();
            RuleFor(x => x.Description).DescriptionRule();
        }
    }
}

