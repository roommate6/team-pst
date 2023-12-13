namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<List<Recipe>> GetAllWithIngredients();
        Task<Recipe> GetByIdWithIngredients(int id);
    }
}
