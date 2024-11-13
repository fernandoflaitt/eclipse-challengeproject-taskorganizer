using Eclipse.ChallengeProject.TaskOrganizer.Api.Exceptions;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Projects.CreateProject;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using FluentValidation;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Api.Configurations;

public static class IoCConfig
{
    public static void ConfigureMigrations(string? defaultConnection) => new AppDbContextFactory().RunPendingMigrations(defaultConnection!);

    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommandValidator).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(CreateProjectCommandValidator).Assembly);
    }
}
