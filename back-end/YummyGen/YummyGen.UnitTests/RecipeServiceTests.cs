using Moq;
using YummyGen.Application;
using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Tests
{
    [TestClass]
    public class RecipeServiceTests
    {
        [TestMethod]
        public async Task AddRecipe_ReturnsAddedRecipeDto()
        {
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeToAdd = new AddRecipeDto
            {
                Name = "Pancakes",
                ShortDescription = "Delicious pancakes"
            };
            var addedRecipe = new Recipe
            {
                Id = 1,
                Name = "Pancakes",
                ShortDescription = "Delicious pancakes"
            };
            mockRepository.Setup(repo => repo.Add(It.IsAny<Recipe>())).ReturnsAsync(addedRecipe);

            var service = new RecipeService(mockRepository.Object);

            var result = await service.AddRecipe(recipeToAdd);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pancakes", result.Name);
        }

        [TestMethod]
        public async Task GetAllRecipes_ReturnsListOfRecipeDtos()
        {
            var mockRepository = new Mock<IRecipeRepository>();
            var sampleRecipes = new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Pancakes" },
                new Recipe { Id = 2, Name = "Pizza" }
            };
            mockRepository.Setup(repo => repo.GetAllWithIngredients()).ReturnsAsync(sampleRecipes);

            var service = new RecipeService(mockRepository.Object);

            var result = await service.GetAllRecipes();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Pancakes", result[0].Name);
            Assert.AreEqual("Pizza", result[1].Name);
        }

    }
}
