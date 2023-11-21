using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class RecipeIngredientService
    {
        private readonly IRecipeIngredientRepository recipeRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        public List<Recipe> GetRecipesByIngredients(List<Ingredient> ingredients)
        {
            var recipes = recipeRepository.GetAll();
            foreach (var recipe in recipes)
            {
                var recipeIngredients = recipe.Ingredients;
                var recipeIngredientIds = recipeIngredients.Select(ri => ri.IngredientId);
                var ingredientIds = ingredients.Select(i => i.Id);
                if (recipeIngredientIds.All(ingredientIds.Contains))
                {
                    return recipe;
                }
            }

            return null;
        }
    }
}