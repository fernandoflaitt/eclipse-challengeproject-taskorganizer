using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Repositories;

public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
{
    public async Task AddAsync(ProjectEntity author, CancellationToken cancellationToken)
        => await context.Projects.AddAsync(author, cancellationToken);

    public async Task<IEnumerable<ProjectEntity>> GetByUserAsync(int userId, CancellationToken cancellationToken)
        => await context.Projects.Where(p => p.Users.Any(u => u.Id == userId)).ToListAsync(cancellationToken);
}
