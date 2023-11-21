using YummyGen.Domain;
using YummyGen.Domain.Dto;

namespace YummyGen.Application
{
    public static class Mapper
    {
        public static RecipeDto GetRecipeDto(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ShortDescription = recipe.ShortDescription,
                Ingredients = recipe.Ingredients.Select(ri => GetIngredientDto(ri.Ingredient)).ToList()
            };
        }

        public static IngredientDto GetIngredientDto(Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
    }
}
