namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class UserProjectEntity
{
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }

    public int ProjectId { get; set; }
    public virtual ProjectEntity Project { get; set; }
}
