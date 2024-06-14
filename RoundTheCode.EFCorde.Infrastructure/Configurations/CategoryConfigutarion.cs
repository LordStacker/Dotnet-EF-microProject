
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundTheCode.EFCore.Domain.Entities;

namespace RoundTheCode.EFCore.Infrastructure.Configurations
{
    internal class CategoryConfigutarion : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category","shop");

            builder.Property(s => s.Name).HasMaxLength(200);

            builder.HasData(new List<Category>
            {
                new Category{Id = 1, Name = "Machines"},
                new Category{Id = 2, Name="Accesories"}
            });
        }
    }
}
