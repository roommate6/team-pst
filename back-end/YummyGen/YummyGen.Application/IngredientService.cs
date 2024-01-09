using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
	public class IngredientService : IIngredientService
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientService(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
		}

		public async Task<List<IngredientDto>> GetAllWithIncludings()
		{
			var ingredients = await _ingredientRepository.GetAllWithIncludings();
			var result = ingredients.Select(i => Mapper.ToIngredientDto(i)).ToList();
			return result;
		}

		public async Task<IngredientDto> GetIngredientByIdWithIncludings(int id)
		{
			var ingredient = await _ingredientRepository.GetIngredientByIdWithIncludings(id);
			var result = Mapper.ToIngredientDto(ingredient);
			return result;
		}

		public async Task<IngredientDto> AddIngredient(AddIngredientDto addIngredientDto, Image image)
		{
			var ingredient = Mapper.ToIngredient(addIngredientDto, image);
			var addedIngredient = await _ingredientRepository.Add(ingredient);
			var result = Mapper.ToIngredientDto(addedIngredient);
			return result;
		}


	}
}
