namespace YummyGen.Domain
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<RecipeIngredient> Recipes { get; set; } = new();
    }
}
