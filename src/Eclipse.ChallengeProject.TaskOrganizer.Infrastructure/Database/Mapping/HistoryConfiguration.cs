namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class HistoryConfiguration : IEntityTypeConfiguration<HistoryEntity>
{
    public void Configure(EntityTypeBuilder<HistoryEntity> builder)
    {
        builder.ToTable("History");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("HistoryId").UseIdentityColumn();
        builder.Property(item => item.Entity).HasColumnName("Detail").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.DateChanged).HasColumnName("DateChanged").HasColumnType("datetime2").IsRequired();
      

        builder.HasOne(h => h.User)
            .WithMany(u => u.History)
            .HasForeignKey(h => h.UserId);

        builder.HasMany(h => h.Details)
            .WithOne(hd => hd.History)
            .HasForeignKey(h => h.HistoryId);
    }
}
