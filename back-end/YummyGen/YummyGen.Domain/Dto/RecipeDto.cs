namespace YummyGen.Domain.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public int ImageId { get; set; }
    }
}
