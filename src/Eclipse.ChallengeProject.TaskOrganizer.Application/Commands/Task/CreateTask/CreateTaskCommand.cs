using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.CreateTask;

public class CreateTaskCommand(TaskPriorityEnum priority, string detail) : IRequest<TaskDto>
{
    public TaskPriorityEnum Priority { get; init; } = priority;
    public string Detail { get; init; } = detail;
    public int? ProjectId { get; private set; }
    public int? UserId { get; private set; }

    public void SetUserId(int? value)
    {
        UserId = value;
    }

    public void SetProjectId(int? value)
    {
        ProjectId = value;
    }
}
