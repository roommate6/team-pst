using YummyGen.Domain;
using YummyGen.Domain.Dto;

namespace YummyGen.Application
{
    public static class Mapper
    {
        public static RecipeDto ToRecipeDto(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ShortDescription = recipe.ShortDescription,
                Ingredients = recipe.Ingredients.Select(ri => ToIngredientDto(ri.Ingredient)).ToList()
            };
        }

        public static IngredientDto ToIngredientDto(Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }

        public static Ingredient ToIngredient(AddIngredientDto ingredient)
        {
            return new Ingredient
            {
                Name = ingredient.Name
            };
        }
    }
}
