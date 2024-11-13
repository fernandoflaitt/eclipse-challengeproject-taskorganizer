using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Projects.CreateProject;

public class CreateProjectCommand(string name) : IRequest<ProjectDto>
{
    public string Name { get; init; } = name;

    public int? UserId { get; private set; }

    public void SetUserId(int? value)
    {
        UserId = value;
    }
}
