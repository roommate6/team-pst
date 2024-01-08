using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YummyGen.Domain;

namespace YummyGen.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext<User>
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
			modelBuilder.Entity<RecipeIngredient>()
				.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

			modelBuilder.Entity<Recipe>()
				.HasMany(r => r.Ingredients)
				.WithMany(r => r.Recipes)
				.UsingEntity<RecipeIngredient>();

			modelBuilder.Entity<Recipe>()
				.HasOne(r => r.Image)
				.WithMany(im => im.Recipes);

			modelBuilder.Entity<Ingredient>()
				.HasOne(i => i.Image)
				.WithMany(im => im.Ingredients);


			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}
