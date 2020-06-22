using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class ClassEntitySchemaDefinition :
        IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("class");
        
            builder.HasIndex(e => e.TeacherId)
                .HasName("fk_class_teacher1_idx");
        
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsUnicode(false);
        
            builder.Property(e => e.TeacherId)
                .HasColumnName("teacher_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.Class)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_teacher1");
        }
    }
}