using Moq;
using YummyGen.Application;
using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Tests
{
    [TestClass]
    public class RecipeIngredientServiceTests
    {
        [TestMethod]
        public async Task GetRecipesByIngredients_ReturnsListOfRecipeDtos()
        {
            var mockRecipeIngredientRepository = new Mock<IRecipeIngredientRepository>();
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockIngredientRepository = new Mock<IIngredientRepository>();
            
            var flour = new Ingredient { Id = 1, Name = "Flour" };
            var cheese = new Ingredient { Id = 2, Name = "Cheese" };
            var sampleIngredients = new List<Ingredient> { flour, cheese };

            var pizza = new Recipe { Id = 1, Name = "Pizza", Ingredients = sampleIngredients };

            var sampleRecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = 1, RecipeId = 1, Recipe = pizza },
            };

            mockRecipeIngredientRepository.Setup(repo => repo.GetByIngredients(It.IsAny<List<int>>())).ReturnsAsync(sampleRecipeIngredients);

            var service = new RecipeIngredientService(mockRecipeIngredientRepository.Object, mockRecipeRepository.Object, mockIngredientRepository.Object);

            var result = await service.GetRecipesByIngredients(new List<string>() { "Flour", "Cheese" });

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Pizza", result[0].Name);
        }

        [TestMethod]
        public async Task AddIngredientToRecipe_ReturnsUpdatedRecipeDto()
        {
            var mockRecipeIngredientRepository = new Mock<IRecipeIngredientRepository>();
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockIngredientRepository = new Mock<IIngredientRepository>();

            var ingredientId = 1;
            var recipeId = 1;

            mockRecipeIngredientRepository
                .Setup(repo => repo.Add(It.IsAny<RecipeIngredient>()))
                .ReturnsAsync(new RecipeIngredient { IngredientId = ingredientId, RecipeId = recipeId });

            var sampleIngredients = new List<Ingredient>
            {
                new Ingredient { Id = ingredientId, Name = "Flour" },
                new Ingredient { Id = 2, Name = "Cheese" }
            };

            var updatedRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Pizza",
                Ingredients = sampleIngredients
            };

            mockRecipeRepository
                .Setup(repo => repo.GetByIdWithIngredients(It.IsAny<int>()))
                .ReturnsAsync(updatedRecipe);

            var service = new RecipeIngredientService(mockRecipeIngredientRepository.Object, mockRecipeRepository.Object, mockIngredientRepository.Object);

            var result = await service.AddIngredientToRecipe(ingredientId, recipeId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pizza", result.Name);
            Assert.IsNotNull(result.Ingredients);
            Assert.AreEqual(2, result.Ingredients.Count);
            Assert.AreEqual("Flour", result.Ingredients[0].Name);
            Assert.AreEqual("Cheese", result.Ingredients[1].Name);
        }
    }
}

