namespace YummyGen.Domain.Interfaces
{
    public interface IRecipeIngredientRepository : IRepository<RecipeIngredient>
    {
        Task<List<RecipeIngredient>> GetByIngredientsWithIncludings(List<int> ingredientsIds);
    }
}
