using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserProjectEntity> UsersProjects { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<TaskCommentEntity> TaskComments { get; set; }
    public DbSet<HistoryEntity> History { get; set; }
    public DbSet<HistoryDetailEntity> HistoryDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
