using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            _ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public async Task<List<RecipeDto>> GetRecipesByIngredientsNamesWithIncludings(List<string> ingredientsNames)
        {
            var ingredients = await _ingredientRepository.GetIngredientsByNames(ingredientsNames.Select(i => i.ToLower()).ToList());
            var ingredientsIds = ingredients.Select(i => i.Id).ToList();
            return await GetRecipesByIngredientsIdsWithIncludings(ingredientsIds);
        }

		public async Task<List<RecipeDto>> GetRecipesByIngredientsIdsWithIncludings(List<int> ingredientsIds)
		{
			var recipeIngredients = await _recipeIngredientRepository.GetByIngredientsWithIncludings(ingredientsIds);
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