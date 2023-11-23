using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        public async Task<List<RecipeDto>> GetAllRecipes()
        {
            var recipes = await recipeRepository.GetAll();
            var result = recipes.Select(r => Mapper.ToRecipeDto(r)).ToList();
            return result;
        }
    }
}
