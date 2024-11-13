namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

public class HistoryDetailEntity
{
    public int Id { get; private set; }
    public string Field { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public int HistoryId { get; private set; }
    public virtual HistoryEntity History { get; private set; }
}
