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

        public async Task<RecipeDto> AddRecipe(AddRecipeDto addRecipeDto)
        {
            var recipe = Mapper.ToRecipe(addRecipeDto);
            var addedRecipe = await recipeRepository.Add(recipe);
            var result = Mapper.ToRecipeDto(addedRecipe);
            return result;
        }

        public async Task<List<RecipeDto>> GetAllRecipes()
        {
            var recipes = await recipeRepository.GetAllWithIngredients();
            var result = recipes.Select(r => Mapper.ToRecipeDto(r)).ToList();
            return result;
        }
    }
}
