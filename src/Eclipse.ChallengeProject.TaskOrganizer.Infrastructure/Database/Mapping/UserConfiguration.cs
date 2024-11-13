namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("UserId").UseIdentityColumn();
        builder.Property(item => item.Name).HasColumnName("Name").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.Function).HasColumnName("Function").HasColumnType("int").IsRequired();

        builder.HasMany(u => u.History)
            .WithOne(h => h.User)
            .HasForeignKey(h => h.UserId);

        builder.HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        builder.HasMany(u => u.Projects)
            .WithMany(p => p.Users);

        builder.HasMany(p => p.UserProject)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        builder.HasData(
              new UserEntity { Id = 1, Name = "User Manager 1", Function = UserFunctionEnum.Manager },
              new UserEntity { Id = 2, Name = "User Manager 2", Function = UserFunctionEnum.Manager },
              new UserEntity { Id = 3, Name = "User Developer 1", Function = UserFunctionEnum.Developer },
              new UserEntity { Id = 4, Name = "User Developer 2", Function = UserFunctionEnum.Developer },
              new UserEntity { Id = 5, Name = "User Developer 3", Function = UserFunctionEnum.Developer });
    }
}