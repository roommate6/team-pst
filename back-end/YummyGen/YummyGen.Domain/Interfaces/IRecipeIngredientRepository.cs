namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeIngredientRepository : IRepository<RecipeIngredient>
    {
        Task<List<RecipeIngredient>> GetByIngredients(List<int> ingredientsIds);
    }
}
