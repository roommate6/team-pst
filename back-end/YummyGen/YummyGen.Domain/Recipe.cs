using System.ComponentModel.DataAnnotations;

namespace YummyGen.Domain
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public List<RecipeIngredient> Ingredients { get; set; } = new();
    }
}