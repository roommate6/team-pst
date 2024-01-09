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

        public async Task<Recipe> GetByIdWithIngredientsAndWithIncludings(int id)
        {
            var recipe = await context.Recipes
                .Where(r => r.Id == id)
                .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Image)
                .Include(r => r.Image)
                .FirstOrDefaultAsync();
            return recipe;
        }

        public async Task<List<Recipe>> GetAllWithIngredientsAndWithIncludings()
        {
            var recipes = await context.Recipes
                .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Image)
                .Include(r => r.Image)
                .ToListAsync();
            return recipes;
        }
    }
}
