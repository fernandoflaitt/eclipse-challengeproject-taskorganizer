using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;

public class ProjectDto(int id, string name, IEnumerable<UserDto> users, IEnumerable<TaskDto> tasks)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public IEnumerable<UserDto> Users { get; set; } = users;
    public IEnumerable<TaskDto> Tasks { get; set; } = tasks;

    public static implicit operator ProjectDto(ProjectEntity entity)
    {
        return new ProjectDto(entity.Id, entity.Name, entity.Users.Select(x => (UserDto)x), entity.Tasks.Select(x => (TaskDto)x));
    }
}
