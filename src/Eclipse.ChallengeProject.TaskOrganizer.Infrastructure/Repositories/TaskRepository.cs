using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task AddAsync(TaskEntity entity, CancellationToken cancellationToken)
       => await context.Tasks.AddAsync(entity, cancellationToken);

    public async Task DeleteAsync(int taskId, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(c => c.Id == taskId, cancellationToken);

        if (task is null) return;

        context.Tasks.Remove(task);
    }

    public async Task<TaskEntity?> GetByIdAsync(int taskId, CancellationToken cancellationToken)
        => await context.Tasks.FirstOrDefaultAsync(c => c.Id == taskId, cancellationToken);

    public async Task<IEnumerable<TaskEntity>> GetByProjectAsync(int projectId, CancellationToken cancellationToken)
        => await context.Tasks.Where(p => p.ProjectId == projectId).ToListAsync(cancellationToken);

    public async Task UpdateAsync(TaskEntity task, CancellationToken cancellationToken)
    {
        context.Entry(task).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
