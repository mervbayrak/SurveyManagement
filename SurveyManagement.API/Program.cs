using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey;
using SurveyManagement.Application.Mappings;
using SurveyManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateSurveyCommand).Assembly));

builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseInMemoryDatabase("SurveyDb")); 

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

