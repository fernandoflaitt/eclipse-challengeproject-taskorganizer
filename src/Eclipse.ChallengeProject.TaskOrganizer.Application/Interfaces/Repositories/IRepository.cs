namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
}
