using YummyGen.Domain;
using YummyGen.Domain.Dto;

namespace YummyGen.Application
{
    public interface IIngredientService
    {
        Task<IngredientDto> AddIngredient(AddIngredientDto ingredientDto, Image image);
        Task<List<IngredientDto>> GetAllIngredients();
    }
}