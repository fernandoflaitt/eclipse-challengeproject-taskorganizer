using Eclipse.ChallengeProject.TaskOrganizer.Api.Configurations;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.ConfigureMediatr();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(defaultConnection));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<ApplicationDbContext>());
IoCConfig.ConfigureMigrations(defaultConnection);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
