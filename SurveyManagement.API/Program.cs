using Microsoft.EntityFrameworkCore;
using SurveyManagement.API.Middlewares;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey;
using SurveyManagement.Application.Common.Mappings;
using SurveyManagement.Infrastructure.Persistence;
using SurveyManagement.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using SurveyManagement.Application.Common.Behaviors;
using SurveyManagement.Application.Messaging.Interfaces;
using SurveyManagement.Infrastructure.Messaging;
using SurveyManagement.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<IApplicationMarker>();
    cfg.RegisterServicesFromAssemblyContaining<IInfrastructureMarker>();
});


builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseInMemoryDatabase("SurveyDb")); 

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddValidatorsFromAssemblyContaining<CreateSurveyCommandValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


var handlerTypes = typeof(IEventHandlerMarker).Assembly
    .GetTypes()
    .Where(t => !t.IsAbstract && !t.IsInterface)
    .SelectMany(t => t.GetInterfaces(), (type, iface) => new { type, iface })
    .Where(x => x.iface.IsGenericType && x.iface.GetGenericTypeDefinition() == typeof(IEventHandler<>))
    .ToList();

foreach (var registration in handlerTypes)
{
    builder.Services.AddScoped(registration.iface, registration.type);
}

MassTransitConfigurator.Configure(
    builder.Services,
    builder.Configuration,
    typeof(IEventHandlerMarker).Assembly
);
builder.Services.AddScoped<IEventPublisher, MassTransitEventPublisher>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

