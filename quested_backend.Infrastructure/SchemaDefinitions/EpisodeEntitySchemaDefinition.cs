using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class EpisodeEntitySchemaDefinition :
        IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(e => new { e.Id, e.SeasonId })
                .HasName("PRIMARY");
        
            builder.ToTable("episode");
        
            builder.HasIndex(e => e.SeasonId)
                .HasName("fk_episode_course1_idx");
        
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.SeasonId)
                .HasColumnName("season_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsUnicode(false);
        
            builder.HasOne(d => d.Season)
                .WithMany(p => p.Episode)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_episode_course1");
        }
    }
}