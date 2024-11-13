using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class HistoryDetailDto(int id, string field, string oldValue, string newValue, HistoryEntity history)
{
    public int Id { get; set; } = id;
    public string Field { get; set; } = field;
    public string OldValue { get; set; } = oldValue;
    public string NewValue { get; set; } = newValue;
    public HistoryEntity History { get; set; } = history;

    public static implicit operator HistoryDetailDto(HistoryDetailEntity entity)
    {
        return new HistoryDetailDto(entity.Id, entity.Field, entity.OldValue, entity.NewValue, entity.History);
    }
}
