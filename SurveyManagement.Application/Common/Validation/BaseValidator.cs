using FluentValidation;

namespace SurveyManagement.Application.Common.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        // Gerekirse loglama, context ya da ortak işlemler burada yapılabilir.
        protected BaseValidator() { }
    }
}
