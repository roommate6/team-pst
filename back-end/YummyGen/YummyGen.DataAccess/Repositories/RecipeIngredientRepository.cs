using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class RecipeIngredientRepository : RepositoryBase<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
