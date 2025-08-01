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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateSurveyCommand).Assembly));

builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseInMemoryDatabase("SurveyDb")); 

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddValidatorsFromAssemblyContaining<CreateSurveyCommandValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

MassTransitConfigurator.Configure(
    builder.Services,
    builder.Configuration,
    typeof(IEventHandlerMarker).Assembly
);
builder.Services.AddScoped<IEventPublisher, MassTransitEventPublisher>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

