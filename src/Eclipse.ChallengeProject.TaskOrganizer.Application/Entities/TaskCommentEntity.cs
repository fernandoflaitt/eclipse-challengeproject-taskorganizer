namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class TaskCommentEntity
{
    public int Id { get; private set; }
    public string Description { get; set; }
    public int TaskId { get; private set; }
    public virtual TaskEntity Task { get; private set; }
}
