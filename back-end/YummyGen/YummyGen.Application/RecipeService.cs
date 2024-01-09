using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        public async Task<RecipeDto> AddRecipe(AddRecipeDto addRecipeDto, Image image)
        {
            var recipe = Mapper.ToRecipe(addRecipeDto, image);
            var addedRecipe = await _recipeRepository.Add(recipe);
            var result = Mapper.ToRecipeDto(addedRecipe);
            return result;
		}

        public async Task<List<RecipeDto>> GetAllRecipesWithIncludings()
        {
            var recipes = await _recipeRepository.GetAllWithIngredientsAndWithIncludings();
            var result = recipes.Select(r => Mapper.ToRecipeDto(r)).ToList();
            return result;
        }
    }
}
