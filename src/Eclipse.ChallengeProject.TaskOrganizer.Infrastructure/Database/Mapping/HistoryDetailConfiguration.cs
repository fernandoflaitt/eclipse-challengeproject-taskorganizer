namespace Eclipse.ChallengeProject.TaskOrganizer.Infra.Data.Database.Mapping;

public class HistoryDetailConfiguration : IEntityTypeConfiguration<HistoryDetailEntity>
{
    public void Configure(EntityTypeBuilder<HistoryDetailEntity> builder)
    {
        builder.ToTable("HistoryDetail");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("HistoryDetailId").UseIdentityColumn();
        builder.Property(item => item.Field).HasColumnName("Field").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.OldValue).HasColumnName("OldValue").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.NewValue).HasColumnName("NewValue").HasColumnType("varchar(40)").IsRequired();

        builder.HasOne(hd => hd.History)
            .WithMany(h => h.Details)
            .HasForeignKey(hd => hd.HistoryId);
    }
}
