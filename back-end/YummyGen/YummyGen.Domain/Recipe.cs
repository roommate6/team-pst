using System.ComponentModel.DataAnnotations;

namespace YummyGen.Domain
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public List<Ingredient> Ingredients { get; } = new();
        public List<RecipeIngredient> RecipeIngredients { get; } = new();
        public Image Image { get; set; }
    }
}