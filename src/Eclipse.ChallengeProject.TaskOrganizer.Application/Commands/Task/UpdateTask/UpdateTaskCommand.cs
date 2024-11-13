using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.UpdateTask;

public class UpdateTaskCommand(TaskPriorityEnum priority, TaskStatusEnum status, string detail) : IRequest
{
    public int? Id { get; private set; }
    public TaskStatusEnum Status { get; init; } = status;
    public string Detail { get; init; } = detail;
    public int? UserId { get; private set; }

    public void SetId(int? value)
    {
        Id = value;
    }

    public void SetUserId(int? value)
    {
        UserId = value;
    }
}
