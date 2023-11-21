using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<List<RecipeDto>> GetRecipesByIngredients(List<int> ingredientIds);
    }
}
