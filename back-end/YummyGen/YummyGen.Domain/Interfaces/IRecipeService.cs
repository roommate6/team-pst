using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> AddRecipe(AddRecipeDto addRecipeDto);
        Task<List<RecipeDto>> GetAllRecipes();
    }
}