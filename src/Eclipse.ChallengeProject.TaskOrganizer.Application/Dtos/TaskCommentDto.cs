using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class TaskCommentDto(int id, string description, TaskDto task)
{
    public int Id { get; private set; } = id;
    public string Description { get; set; } = description;
    public TaskDto Task { get; private set; } = task;

    public static implicit operator TaskCommentDto(TaskCommentEntity entity)
    {
        return new TaskCommentDto(entity.Id, entity.Description, entity.Task);
    }
}
