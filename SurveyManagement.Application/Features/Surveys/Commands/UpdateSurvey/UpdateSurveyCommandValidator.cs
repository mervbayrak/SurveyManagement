using System;
using FluentValidation;
using SurveyManagement.Application.Common.Validation;

namespace SurveyManagement.Application.Features.Surveys.Commands.UpdateSurvey
{
    public class UpdateSurveyCommandValidator : BaseValidator<UpdateSurveyCommand>
    {
        public UpdateSurveyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Anket ID boş olamaz.");
            RuleFor(x => x.Title).TitleRule();
            RuleFor(x => x.Description).DescriptionRule();
        }
    }
}

