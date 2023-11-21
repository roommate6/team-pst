using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

		public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
