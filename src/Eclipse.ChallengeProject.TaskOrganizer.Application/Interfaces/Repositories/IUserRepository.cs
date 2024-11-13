using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int userId, CancellationToken cancellationToken);
}
