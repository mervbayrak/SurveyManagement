using FluentValidation;

namespace SurveyManagement.Application.Common.Validation
{
    public static class SurveyValidationRules
    {
        public static IRuleBuilder<T, string> TitleRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.NotEmpty().WithMessage("Başlık boş olamaz.")
                       .MaximumLength(100).WithMessage("Başlık 100 karakteri geçemez.");
        }

        public static IRuleBuilder<T, string> DescriptionRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.MaximumLength(500).WithMessage("Açıklama 500 karakteri geçemez.");
        }
    }
}
