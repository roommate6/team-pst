using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> AddRecipe(AddRecipeDto addRecipeDto, Image image);
        Task<List<RecipeDto>> GetAllRecipesWithIncludings();
        Task<RecipeDto> GetRecipeByIdWithIncludings(int id);
    }
}