using System.ComponentModel.DataAnnotations;

namespace YummyGen.Domain
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; } = new();
    }
}