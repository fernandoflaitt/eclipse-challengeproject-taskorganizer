using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;

public interface IProjectRepository : IRepository<ProjectEntity>
{
    Task<IEnumerable<ProjectEntity>> GetByUserAsync(int userId, CancellationToken cancellationToken);
}
