using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class QuestionEntitySchemaDefinition :
        IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(e => new { e.Id, e.EpisodeId, e.EpisodeSeasonId })
                .HasName("PRIMARY");
        
            builder.ToTable("question");
        
            builder.HasIndex(e => new { e.EpisodeId, e.EpisodeSeasonId })
                .HasName("fk_question_episode1_idx");
        
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.EpisodeId)
                .HasColumnName("episode_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.EpisodeSeasonId)
                .HasColumnName("episode_season_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.MaxPoints)
                .HasColumnName("max_points")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.Episode)
                .WithMany(p => p.Question)
                .HasForeignKey(d => new { d.EpisodeId, d.EpisodeSeasonId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_question_episode1");
        }
    }
}