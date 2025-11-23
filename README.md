````markdown
📁 Project Structure

```

├── SurveyManagement
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── SurveyManagement.csproj
│   ├── appsettings.Development.json
│   └── appsettings.json
├── SurveyManagement.API
│   ├── Controllers
│   │   ├── BaseApiController.cs
│   │   └── SurveyController.cs
│   ├── Middlewares
│   │   └── ExceptionHandlingMiddleware.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── SurveyManagement.API.csproj
│   ├── appsettings.Development.json
│   └── appsettings.json
├── SurveyManagement.Application
│   ├── Abstractions
│   │   ├── IApplicationMarker.cs
│   │   ├── IBaseRepository.cs
│   │   └── IUnitOfWork.cs
│   ├── Common
│   │   ├── Behaviors
│   │   │   ├── LoggingBehavior.cs
│   │   │   └── ValidationBehavior.cs
│   │   ├── Extensions
│   │   │   └── StringExtensions.cs
│   │   ├── Mappings
│   │   │   └── MappingProfile.cs
│   │   └── Validation
│   │       ├── BaseValidator.cs
│   │       └── SurveyValidationRules.cs
│   ├── DTOs
│   │   └── SurveyDto.cs
│   ├── Exceptions
│   │   └── NotFoundException.cs
│   ├── Features
│   │   └── Surveys
│   │       ├── Commands
│   │       │   ├── CreateSurvey
│   │       │   │   ├── CreateSurveyCommand.cs
│   │       │   │   ├── CreateSurveyCommandHandler.cs
│   │       │   │   └── CreateSurveyCommandValidator.cs
│   │       │   ├── DeleteSurvey
│   │       │   │   ├── DeleteSurveyCommand.cs
│   │       │   │   └── DeleteSurveyCommandHandler.cs
│   │       │   └── UpdateSurvey
│   │       │       ├── UpdateSurveyCommand.cs
│   │       │       ├── UpdateSurveyCommandHandler.cs
│   │       │       └── UpdateSurveyCommandValidator.cs
│   │       └── Queries
│   │           ├── GetAll
│   │           │   ├── GetAllSurveysQuery.cs
│   │           │   └── GetAllSurveysQueryHandler.cs
│   │           └── GetSurveyById
│   │               ├── GetSurveyByIdQuery.cs
│   │               └── GetSurveyByIdQueryHandler.cs
│   ├── Messaging
│   │   ├── Events
│   │   │   └── Survey
│   │   │       ├── SurveyCreated
│   │   │       │   ├── SurveyCreatedEvent.cs
│   │   │       │   └── SurveyCreatedEventHandler.cs
│   │   │       └── SurveyUpdated
│   │   │           ├── SurveyUpdatedEvent.cs
│   │   │           └── SurveyUpdatedEventHandler.cs
│   │   └── Interfaces
│   │       ├── IEventHandler.cs
│   │       ├── IEventHandlerMarker.cs
│   │       └── IEventPublisher.cs
│   ├── SurveyManagement.Application.csproj
│   └── Wrappers
│       └── Response.cs
├── SurveyManagement.Domain
│   ├── Common
│   │   ├── BaseEntity.cs
│   │   └── IDomainEvent.cs
│   ├── Entities
│   │   └── Survey.cs
│   ├── Events
│   │   ├── AggregateRoot.cs
│   │   └── SurveyCreatedDomainEvent.cs
│   └── SurveyManagement.Domain.csproj
├── SurveyManagement.Infrastructure
│   ├── DependencyInjection
│   │   └── IInfrastructureMarker.cs
│   ├── Extensions
│   │   └── MediatorExtensions.cs
│   ├── Messaging
│   │   ├── EventHandlers
│   │   │   └── SurveyCreatedDomainEventHandler.cs
│   │   ├── MassTransitConfigurator.cs
│   │   ├── MassTransitEventAdapter.cs
│   │   └── MassTransitEventPublisher.cs
│   ├── Persistence
│   │   └── SurveyDbContext.cs
│   ├── Repositories
│   │   ├── BaseRepository.cs
│   │   └── EfUnitOfWork.cs
│   └── SurveyManagement.Infrastructure.csproj
├── SurveyManagement.sln
└── structure.txt

43 directories, 63 files
