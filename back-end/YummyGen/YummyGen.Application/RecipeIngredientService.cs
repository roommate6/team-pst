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

        public async Task<List<RecipeDto>> GetRecipesByIngredientsWithIncludings(List<string> ingredientNames)
        {
            var ingredients = await _ingredientRepository.GetIngredientsByNames(ingredientNames.Select(i => i.ToLower()).ToList());
            var ingredientIds = ingredients.Select(i => i.Id).ToList();
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