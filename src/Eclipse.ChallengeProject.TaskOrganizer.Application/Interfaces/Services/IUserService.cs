using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Enums;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Services;

public interface IUserService
{
    Task<UserEntity?> GetByIdAsync(int userId);
    Task<bool> Exists(int userId);
    Task<bool> Permission(int userId, UserFunctionEnum functionPermittedOperation);
}
