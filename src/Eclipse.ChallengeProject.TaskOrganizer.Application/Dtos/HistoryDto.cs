using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class HistoryDto(int id, string entity, DateTime dateChanged, UserEntity user, IEnumerable<HistoryDetailDto> details)
{
    public int Id { get; private set; } = id;
    public string Entity { get; set; } = entity;
    public DateTime DateChanged { get; private set; } = dateChanged;
    public UserEntity User { get; private set; } = user;
    public IEnumerable<HistoryDetailDto> Details { get; set; } = details;

    public static implicit operator HistoryDto(HistoryEntity entity)
    {
        return new HistoryDto(entity.Id, entity.Entity, entity.DateChanged, entity.User, entity.Details.Select(x => (HistoryDetailDto)x));
    }
}
