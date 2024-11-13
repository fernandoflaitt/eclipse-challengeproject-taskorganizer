using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class TaskDto(int id, TaskPriorityEnum priority, TaskStatusEnum status, string detail, ProjectDto project, UserDto user, IEnumerable<TaskCommentDto> comments)
{
    public int Id { get; set; } = id;
    public TaskPriorityEnum Priority { get; set; } = priority;
    public TaskStatusEnum Status { get; set; } = status;
    public string Detail { get; set; } = detail;
    public ProjectDto Project { get; set; } = project;
    public UserDto User { get; set; } = user;
    public IEnumerable<TaskCommentDto> Comments { get; set; } = comments;

    public static implicit operator TaskDto(TaskEntity entity)
    {
        return new TaskDto(entity.Id, entity.Priority, entity.Status, entity.Detail, entity.Project, entity.User, entity.Comments.Select(x => (TaskCommentDto)x));
    }
}
