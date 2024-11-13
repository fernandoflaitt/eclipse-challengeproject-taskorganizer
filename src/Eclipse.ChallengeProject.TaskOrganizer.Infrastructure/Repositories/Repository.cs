using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity, cancellationToken);
    }
}
