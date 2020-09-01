using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class TeacherEntitySchemaDefinition : 
        IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("teacher");
        
            builder.HasIndex(e => e.SchoolId)
                .HasName("fk_teacher_school1_idx");
        
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.Firstname)
                .HasColumnName("firstname")
                .HasMaxLength(45)
                .IsUnicode(false);
        
            builder.Property(e => e.Lastname)
                .HasColumnName("lastname")
                .HasMaxLength(45)
                .IsUnicode(false);
        
            builder.Property(e => e.SchoolId)
                .HasColumnName("school_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.School)
                .WithMany(p => p.Teacher)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_school1");
        }
    }
}