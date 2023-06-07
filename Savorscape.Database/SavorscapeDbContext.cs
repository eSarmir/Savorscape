using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Savorscape.Database.Models;
using System.Reflection;

namespace Savorscape.Database
{
    public class SavorscapeDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public SavorscapeDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("SavorscapeDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
