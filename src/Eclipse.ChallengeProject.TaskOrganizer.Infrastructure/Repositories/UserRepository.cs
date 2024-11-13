using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<UserEntity?> GetByIdAsync(int userId, CancellationToken cancellationToken)
        => await context.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
}
