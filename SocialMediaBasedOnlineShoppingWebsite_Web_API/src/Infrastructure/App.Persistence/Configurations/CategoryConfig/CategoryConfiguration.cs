using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations.CategoryConfig
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasAnnotation("Categories", "This table is used for storing categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasAnnotation("Id", "Unique identifier for the entity")
                   .HasColumnType("uuid")
                   .HasColumnName("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnOrder(1);

            builder.Property(c => c.Name)
                   .HasAnnotation("Name", "Name is required for validation purposes")
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar")
                   .HasColumnName("Name")
                   .HasColumnOrder(2);

            builder.Property(c => c.Description)
                   .HasAnnotation("Description", "Description is required for validation purposes")
                   .IsRequired()
                   .HasMaxLength(250)
                   .HasColumnType("varchar")
                   .HasColumnName("Description")
                   .HasColumnOrder(3);
        }
    }
}
