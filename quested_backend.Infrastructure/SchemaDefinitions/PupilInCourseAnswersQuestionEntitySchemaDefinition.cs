using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class PupilInCourseAnswersQuestionEntitySchemaDefinition :
        IEntityTypeConfiguration<PupilInCourseAnswersQuestion>
    {
        public void Configure(EntityTypeBuilder<PupilInCourseAnswersQuestion> builder)
        {
            builder.HasKey(e
                            => new { e.PupilInCourseCourseId, e.PupilInCoursePupilId,
                                    e.QuestionId, e.QuestionEpisodeId, e.QuestionEpisodeSeasonId })
                    .HasName("PRIMARY");
        
            builder.ToTable("pupil_in_course_answers_question");
        
            builder.HasIndex(e => new { e.PupilInCourseCourseId, e.PupilInCoursePupilId })
                    .HasName("fk_pupil_in_course_has_question_pupil_in_course1_idx");
        
            builder.HasIndex(e => new { e.QuestionId, e.QuestionEpisodeId, e.QuestionEpisodeSeasonId })
                    .HasName("fk_pupil_in_course_has_question_question1_idx");
        
            builder.Property(e => e.PupilInCourseCourseId)
                    .HasColumnName("pupil_in_course_course_id")
                    .HasColumnType("int(11)");
        
            builder.Property(e => e.PupilInCoursePupilId)
                    .HasColumnName("pupil_in_course_pupil_id")
                    .HasColumnType("int(11)");
        
            builder.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");
        
            builder.Property(e => e.QuestionEpisodeId)
                    .HasColumnName("question_episode_id")
                    .HasColumnType("int(11)");
        
            builder.Property(e => e.QuestionEpisodeSeasonId)
                    .HasColumnName("question_episode_season_id")
                    .HasColumnType("int(11)");
        
            builder.Property(e => e.AchievedPoints)
                    .HasColumnName("achieved_points")
                    .HasColumnType("int(11)");
        
            builder.HasOne(d => d.PupilInCourse)
                    .WithMany(p => p.PupilInCourseAnswersQuestion)
                    .HasForeignKey(d => new { d.PupilInCourseCourseId, d.PupilInCoursePupilId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_in_course_has_question_pupil_in_course1");
        
            builder.HasOne(d => d.Question)
                    .WithMany(p => p.PupilInCourseAnswersQuestion)
                    .HasForeignKey(d => new { d.QuestionId, d.QuestionEpisodeId, d.QuestionEpisodeSeasonId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_in_course_has_question_question1");
        }
    }
}