using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class UserEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required UserFunctionEnum Function { get; set; }
    public virtual ICollection<HistoryEntity> History { get; set; } = new List<HistoryEntity>();
    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    public virtual ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    public virtual ICollection<UserProjectEntity> UserProject { get; set; } = new List<UserProjectEntity>();
}
