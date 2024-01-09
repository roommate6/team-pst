using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<RecipeDto> AddIngredientToRecipeWithIncludings(int ingredientId, int recipeId);
        Task<List<RecipeDto>> GetRecipesByIngredientsWithIncludings(List<string> ingredientNames);
    }
}
