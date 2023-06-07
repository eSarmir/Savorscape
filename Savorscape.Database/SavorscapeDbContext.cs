using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Savorscape.Database.Models;
using System.Reflection;

namespace Savorscape.Database
{
    public sealed class SavorscapeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
