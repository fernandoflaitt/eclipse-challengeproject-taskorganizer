namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class TaskCommentConfiguration : IEntityTypeConfiguration<TaskCommentEntity>
{
    public void Configure(EntityTypeBuilder<TaskCommentEntity> builder)
    {
        builder.ToTable("TaskComment");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("TaskCommentId").UseIdentityColumn();
        builder.Property(item => item.Description).HasColumnName("Description").HasColumnType("varchar(40)").IsRequired();

        builder.HasOne(tc => tc.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(t => t.TaskId);
    }
}
