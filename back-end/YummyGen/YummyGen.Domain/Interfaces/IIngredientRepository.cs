namespace YummyGen.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
		Task<IEnumerable<Ingredient>> GetAllWithIncludings();
		Task<Ingredient> GetIngredientByIdWithIncludings(int id);
        Task<IEnumerable<Ingredient>> GetIngredientsByNames(List<string> ingredientNames);
    }
}
