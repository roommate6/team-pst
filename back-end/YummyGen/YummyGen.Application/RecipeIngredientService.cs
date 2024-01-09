using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository recipeIngredientRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly IIngredientRepository ingredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            this.recipeIngredientRepository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
            this.recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            this.ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public async Task<List<RecipeDto>> GetRecipesByIngredients(List<string> ingredientNames)
        {
            var ingredients = await ingredientRepository.GetIngredientsByNames(ingredientNames.Select(i => i.ToLower()).ToList());
            var ingredientIds = ingredients.Select(i => i.Id).ToList();
            var recipeIngredients = await recipeIngredientRepository.GetByIngredients(ingredientIds);
            var recipes = recipeIngredients.Select(ri => ri.Recipe).ToList();
            var result = recipes.Select(r => Mapper.ToRecipeDto(r)).ToList();
            return result;
        }

        public async Task<RecipeDto> AddIngredientToRecipe(int ingredientId, int recipeId)
        {
            var recipeIngredient = new RecipeIngredient
            {
                IngredientId = ingredientId,
                RecipeId = recipeId
            };

            await recipeIngredientRepository.Add(recipeIngredient);

            var updatedRecipe = await recipeRepository.GetByIdWithIngredients(recipeId);
            var result = Mapper.ToRecipeDto(updatedRecipe);
            return result;
        }
    }
}