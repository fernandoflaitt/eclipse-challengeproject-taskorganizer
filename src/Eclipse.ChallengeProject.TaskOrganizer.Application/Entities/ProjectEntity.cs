namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class ProjectEntity
{
    public ProjectEntity(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    public virtual ICollection<UserProjectEntity> UserProject { get; set; } = new List<UserProjectEntity>();
}
