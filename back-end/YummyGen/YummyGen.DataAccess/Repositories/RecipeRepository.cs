using Microsoft.EntityFrameworkCore;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Recipe> GetByIdWithIngredients(int id)
        {
            var recipe = await context.Recipes
                .Where(r => r.Id == id)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync();
            return recipe;
        }
    }
}
