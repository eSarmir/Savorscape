using Microsoft.EntityFrameworkCore;
using Savorscape.Database.Models;
using System.Reflection;

namespace Savorscape.Database
{
    public sealed class SavorscapeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }

        public SavorscapeDbContext(DbContextOptions<SavorscapeDbContext> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
