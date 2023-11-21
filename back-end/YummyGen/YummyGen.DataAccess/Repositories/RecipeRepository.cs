using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
