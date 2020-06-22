using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quested_backend.Domain.Entities;

namespace quested_backend.Infrastructure.SchemaDefinitions
{
    public class SchoolEntitySchemaDefinition :
        IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("school");
                
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");
                
            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(45)
                .IsUnicode(false);
                
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}