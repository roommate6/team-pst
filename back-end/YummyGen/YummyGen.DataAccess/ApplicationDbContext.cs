using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YummyGen.Domain;

namespace YummyGen.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Server=localhost;Database=YummyGenDatabase;User Id=postgres;Password=daucufly;");
        }
    }
}
