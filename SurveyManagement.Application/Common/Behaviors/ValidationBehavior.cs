using FluentValidation;
using MediatR;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var errorMessages = failures.Select(f => f.ErrorMessage).ToList();

                    var type = typeof(TResponse);
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(SurveyResult<>))
                    {
                        var resultType = type.GenericTypeArguments[0];
                        var failMethod = typeof(SurveyResult<>)
                            .MakeGenericType(resultType)
                            .GetMethod("Fail", new[] { typeof(List<string>) });

                        return (TResponse)failMethod.Invoke(null, new object[] { errorMessages });
                    }
                }
            }

            return await next();
        }
    }
}
