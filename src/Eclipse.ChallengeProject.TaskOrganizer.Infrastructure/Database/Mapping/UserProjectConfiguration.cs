namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class UserProjectConfiguration : IEntityTypeConfiguration<UserProjectEntity>
{
    public void Configure(EntityTypeBuilder<UserProjectEntity> builder)
    {
        builder.ToTable("UserProject");

        builder.HasKey(up => new { up.ProjectId, up.UserId });

        builder
            .Property(up => up.ProjectId)
            .HasColumnName("ProjectId");

        builder
            .Property(up => up.UserId)
            .HasColumnName("UserId");

        builder
            .HasOne(up => up.User)
            .WithMany(u => u.UserProject)
            .HasForeignKey(up => up.UserId);

        builder
            .HasOne(up => up.Project)
            .WithMany(p => p.UserProject)
            .HasForeignKey(up => up.ProjectId);

        builder.HasIndex(ba => ba.ProjectId).HasDatabaseName("Project_FKIndex1");
        builder.HasIndex(ba => ba.UserId).HasDatabaseName("User_FKIndex2");
    }
}
