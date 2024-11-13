namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Project");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("ProjectId").UseIdentityColumn();
        builder.Property(item => item.Name).HasColumnName("Name").HasColumnType("varchar(40)").IsRequired();

        builder.HasMany(p => p.Users)
            .WithMany(u => u.Projects);

        builder.HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);

        builder.HasMany(p => p.UserProject)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
    }
}
