using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using YummyGen.Domain;

namespace YummyGen.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithMany(r => r.Recipes)
                .UsingEntity<RecipeIngredient>();

            //modelBuilder.Entity<RecipeIngredient>()
            //    .HasOne(ri => ri.Ingredient)
            //    .WithMany(i => i.RecipeIngredients)
            //    .HasForeignKey(ri => ri.IngredientId);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
