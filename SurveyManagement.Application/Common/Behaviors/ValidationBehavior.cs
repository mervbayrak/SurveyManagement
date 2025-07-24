using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SurveyManagement.Application.Wrappers;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
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
                foreach (var failure in failures)
                {
                    _logger.LogWarning("Validation error on {Property}: {Error}", failure.PropertyName, failure.ErrorMessage);
                }

                var errors = failures.Select(f => f.ErrorMessage).ToList();
                var responseType = typeof(TResponse);

                if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(SurveyResult<>))
                {
                    var failMethod = typeof(SurveyResult<>)
                        .MakeGenericType(responseType.GenericTypeArguments[0])
                        .GetMethod(nameof(SurveyResult<object>.Fail), new[] { typeof(List<string>) });

                    return (TResponse)failMethod.Invoke(null, new object[] { errors });
                }

                return null;
            }
        }

        return await next();
    }
}
