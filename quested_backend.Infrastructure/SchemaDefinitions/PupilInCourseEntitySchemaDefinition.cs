using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class PupilInCourseEntitySchemaDefinition :
        IEntityTypeConfiguration<PupilInCourse>
    {
        public void Configure(EntityTypeBuilder<PupilInCourse> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.PupilId })
                .HasName("PRIMARY");
        
            builder.ToTable("pupil_in_course");
        
            builder.HasIndex(e => e.CourseId)
                .HasName("fk_course_instance_has_pupil_course_instance1_idx");
        
            builder.HasIndex(e => e.PupilId)
                .HasName("fk_course_instance_has_pupil_pupil1_idx");
        
            builder.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.PupilId)
                .HasColumnName("pupil_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.Course)
                .WithMany(p => p.PupilInCourse)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_instance_has_pupil_course_instance1");
        
            builder.HasOne(d => d.Pupil)
                .WithMany(p => p.PupilInCourse)
                .HasForeignKey(d => d.PupilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_instance_has_pupil_pupil1");
        }
    }
}