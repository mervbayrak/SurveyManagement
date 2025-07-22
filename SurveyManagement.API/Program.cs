using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey;
using SurveyManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateSurveyCommand).Assembly));

// DbContext
//var s = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<SurveyDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//        configure => { configure.CommandTimeout(90); });
//});


builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseInMemoryDatabase("SurveyDb")); // Geliştirme için InMemory, sonra SQL geçeriz

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();


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

