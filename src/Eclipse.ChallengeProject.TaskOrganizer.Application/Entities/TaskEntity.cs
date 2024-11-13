using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class TaskEntity(TaskPriorityEnum priority, string detail, int projectId, int userId)
{
    public int Id { get; set; }
    public TaskPriorityEnum Priority { get; set; } = priority;
    public TaskStatusEnum Status { get; set; }
    public string Detail { get; set; } = detail;
    public int ProjectId { get; set; } = projectId;
    public virtual ProjectEntity Project { get; set; }
    public int UserId { get; set; } = userId;
    public virtual UserEntity User { get; set; }
    public virtual ICollection<TaskCommentEntity> Comments { get; set; } = new List<TaskCommentEntity>();
}
