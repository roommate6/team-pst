namespace YummyGen.Domain
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Recipe> Recipes { get; set; } = new();
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
    }
}
