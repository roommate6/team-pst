using YummyGen.Domain.Dto;

namespace YummyGen.Application
{
    public interface IIngredientService
    {
        Task<IngredientDto> AddIngredient(AddIngredientDto ingredientDto);
        Task<List<IngredientDto>> GetAllIngredients();
    }
}