using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<RecipeDto> AddIngredientToRecipe(int ingredientId, int recipeId);
        Task<List<RecipeDto>> GetRecipesByIngredients(List<int> ingredientIds);
    }
}
