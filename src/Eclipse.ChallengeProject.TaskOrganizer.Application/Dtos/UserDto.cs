using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class UserDto(int id, string name, UserFunctionEnum function, IEnumerable<HistoryDto> history, IEnumerable<TaskDto> tasks, IEnumerable<ProjectDto> projects)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public UserFunctionEnum Function { get; set; } = function;
    public IEnumerable<HistoryDto> History { get; set; } = history;
    public IEnumerable<TaskDto> Tasks { get; set; } = tasks;
    public IEnumerable<ProjectDto> Projects { get; set; } = projects;

    public static implicit operator UserDto(UserEntity entity)
    {
        return new UserDto(entity.Id, entity.Name, entity.Function, entity.History.Select(x => (HistoryDto)x), entity.Tasks.Select(x => (TaskDto)x), entity.Projects.Select(x => (ProjectDto)x));
    }
}
