using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;

public interface ITaskRepository : IRepository<TaskEntity>
{
    Task<TaskEntity?> GetByIdAsync(int taskId, CancellationToken cancellationToken);
    Task DeleteAsync(int taskId, CancellationToken cancellationToken);
    Task UpdateAsync(TaskEntity task, CancellationToken cancellationToken);
    Task<IEnumerable<TaskEntity>> GetByProjectAsync(int projectId, CancellationToken cancellationToken);
}
