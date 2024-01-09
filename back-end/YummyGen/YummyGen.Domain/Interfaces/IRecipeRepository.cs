namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<List<Recipe>> GetAllWithIngredientsAndWithIncludings();
        Task<Recipe> GetByIdWithIngredientsAndWithIncludings(int id);
    }
}
