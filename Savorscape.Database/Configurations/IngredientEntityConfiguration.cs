using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savorscape.Database.Models;

namespace Savorscape.Database.Configurations
{
    public class IngredientEntityConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasKey(i => i.IngredientId);
            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(i => i.Quantity)
                .IsRequired();
            builder
                .Property(i => i.Unit)
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
