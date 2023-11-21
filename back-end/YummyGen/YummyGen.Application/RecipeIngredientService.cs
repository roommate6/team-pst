using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository recipeIngredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            this.recipeIngredientRepository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
        }

        public async Task<List<RecipeDto>> GetRecipesByIngredients(List<int> ingredientIds)
        {
            var recipeIngredients = await recipeIngredientRepository.GetByIngredients(ingredientIds);
            var recipes = recipeIngredients.Select(ri => ri.Recipe).ToList();
            var result = recipes.Select(r => Mapper.GetRecipeDto(r)).ToList();
            return result;
        }
    }
}