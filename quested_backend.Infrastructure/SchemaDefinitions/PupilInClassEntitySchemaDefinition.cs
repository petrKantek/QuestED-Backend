using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class PupilInClassEntitySchemaDefinition :
        IEntityTypeConfiguration<PupilInClass>
    {
        public void Configure(EntityTypeBuilder<PupilInClass> builder)
        {
            builder.HasKey(e => new { e.PupilId, e.ClassId })
                .HasName("PRIMARY");
        
            builder.ToTable("pupil_in_class");
        
            builder.HasIndex(e => e.ClassId)
                .HasName("fk_pupil_has_class_class1_idx");
        
            builder.HasIndex(e => e.PupilId)
                .HasName("fk_pupil_has_class_pupil1_idx");
        
            builder.Property(e => e.PupilId)
                .HasColumnName("pupil_id")
                .HasColumnType("int(11)");
        
            builder.Property(e => e.ClassId)
                .HasColumnName("class_id")
                .HasColumnType("int(11)");
        
            builder.HasOne(d => d.Class)
                .WithMany(p => p.PupilInClass)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pupil_has_class_class1");
        
            builder.HasOne(d => d.Pupil)
                .WithMany(p => p.PupilInClass)
                .HasForeignKey(d => d.PupilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pupil_has_class_pupil1");
        }
    }
}