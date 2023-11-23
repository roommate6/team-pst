using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAllRecipes();
    }
}