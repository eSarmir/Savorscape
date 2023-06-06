using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savorscape.Database.Models;

namespace Savorscape.Database.Configurations
{
    public class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(r => r.RecipeID);
            builder
                .Property(r => r.RecipeID)
                .IsRequired();
            builder
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(300);
            builder
                .Property(r => r.PreparationTime)
                .IsRequired();
            builder
                .Property(r => r.Difficulty)
                .IsRequired();
            builder
                .Property(r => r.Servings)
                .IsRequired();

            builder
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId)
                .IsRequired();

            builder
                .HasMany(r => r.Instructions)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId)
                .IsRequired();
        }
    }
}
