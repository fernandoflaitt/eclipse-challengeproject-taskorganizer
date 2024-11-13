namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("TaskId").UseIdentityColumn();
        builder.Property(item => item.Priority).HasColumnName("Priority").HasColumnType("int").IsRequired();
        builder.Property(item => item.Status).HasColumnName("Status").HasColumnType("int").IsRequired();
        builder.Property(item => item.Detail).HasColumnName("Detail").HasColumnType("varchar(40)").IsRequired();

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId);

        builder.HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserId);

        builder.HasMany(t => t.Comments)
            .WithOne(c => c.Task)
            .HasForeignKey(c => c.TaskId);
    }
}