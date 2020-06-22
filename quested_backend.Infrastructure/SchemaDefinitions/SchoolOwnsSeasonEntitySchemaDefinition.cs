using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class SchoolOwnsSeasonEntitySchemaDefinition :
        IEntityTypeConfiguration<SchoolOwnsSeason>
    {
        public void Configure(EntityTypeBuilder<SchoolOwnsSeason> builder)
        {
            builder.HasKey(e => new { e.SeasonId, e.SchoolId })
                .HasName("PRIMARY");
        
            builder.ToTable("school_owns_season");
        
            builder.HasIndex(e => e.SchoolId)
                .HasName("fk_season_has_school_school1_idx");
        
            builder.HasIndex(e => e.SeasonId)
                .HasName("fk_season_has_school_season1_idx");
        
            builder.Property(e => e.SeasonId)
                .HasColumnName("season_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.SchoolId)
                .HasColumnName("school_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.School)
                .WithMany(p => p.SchoolOwnsSeason)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_season_has_school_school1");
        
            builder.HasOne(d => d.Season)
                .WithMany(p => p.SchoolOwnsSeason)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_season_has_school_season1");
        }
    }
}