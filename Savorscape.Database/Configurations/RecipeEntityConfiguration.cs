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
                .IsRequired();
        }
    }
}
