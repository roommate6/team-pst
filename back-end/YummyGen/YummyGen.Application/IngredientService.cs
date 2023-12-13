using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public async Task<List<IngredientDto>> GetAllIngredients()
        {
            var ingredients = await ingredientRepository.GetAll();
            var result = ingredients.Select(i => Mapper.ToIngredientDto(i)).ToList();
            return result;
        }

        public async Task<IngredientDto> AddIngredient(AddIngredientDto ingredientDto)
        {
            var ingredient = Mapper.ToIngredient(ingredientDto);
            var addedIngredient = await ingredientRepository.Add(ingredient);
            var result = Mapper.ToIngredientDto(addedIngredient);
            return result;
        }
    }
}
