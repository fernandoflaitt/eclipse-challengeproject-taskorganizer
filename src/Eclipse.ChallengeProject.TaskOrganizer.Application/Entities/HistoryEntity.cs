namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class HistoryEntity
{
    public int Id { get; private set; }
    public string Entity { get; set; }
    public DateTime DateChanged { get; private set; }
    public int UserId { get; private set; }
    public virtual UserEntity User { get; private set; }
    public virtual ICollection<HistoryDetailEntity> Details { get; set; } = new List<HistoryDetailEntity>();
}
