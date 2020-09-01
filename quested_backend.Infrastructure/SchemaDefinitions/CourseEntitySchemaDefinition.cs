using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class CourseEntitySchemaDefinition :
        IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");
        
            builder.HasIndex(e => e.CourseId)
                .HasName("fk_course_instance_course1_idx");
        
            builder.HasIndex(e => e.TeacherId)
                .HasName("fk_course_instance_teacher1_idx");
        
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsUnicode(false);
        
            builder.Property(e => e.TeacherId)
                .HasColumnName("teacher_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.CourseNavigation)
                .WithMany(p => p.Course)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_instance_season1");
        
            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.Course)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_instance_teacher1");
        }
    }
}