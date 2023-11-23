namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> GetByIdWithIngredients(int id);
    }
}
