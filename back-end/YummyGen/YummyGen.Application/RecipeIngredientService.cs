using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        public async Task<List<RecipeDto>> GetRecipesByIngredientsWithIncludings(List<int> ingredientIds)
        {
            var recipeIngredients = await _recipeIngredientRepository.GetByIngredientsWithIncludings(ingredientIds);
            var recipes = recipeIngredients.Select(ri => ri.Recipe).ToList();
            var result = recipes.Select(r => Mapper.ToRecipeDto(r)).ToList();
            return result;
        }

        public async Task<RecipeDto> AddIngredientToRecipeWithIncludings(int ingredientId, int recipeId)
        {
            var recipeIngredient = new RecipeIngredient
            {
                IngredientId = ingredientId,
                RecipeId = recipeId
            };

            await _recipeIngredientRepository.Add(recipeIngredient);

            var updatedRecipe = await _recipeRepository.GetByIdWithIngredientsAndWithIncludings(recipeId);
            var result = Mapper.ToRecipeDto(updatedRecipe);
            return result;
        }
    }
}