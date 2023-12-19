﻿using Moq;
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

            var sampleRecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = 1, RecipeId = 1 },
                new RecipeIngredient { IngredientId = 2, RecipeId = 1 }
            };
            mockRecipeIngredientRepository.Setup(repo => repo.GetByIngredients(It.IsAny<List<int>>())).ReturnsAsync(sampleRecipeIngredients);

            var sampleIngredients = new List<Ingredient>
            {
                new Ingredient { Id = 1, Name = "Flour" },
                new Ingredient { Id = 2, Name = "Cheese" }
            };

            var sampleRecipes = new List<Recipe>
            {
                new Recipe 
                { 
                    Id = 1, 
                    Name = "Pizza", 
                    Ingredients = sampleIngredients
                },
            };

            mockRecipeRepository.Setup(repo => repo.GetByIdWithIngredients(It.IsAny<int>())).ReturnsAsync(sampleRecipes.FirstOrDefault());

            var service = new RecipeIngredientService(mockRecipeIngredientRepository.Object, mockRecipeRepository.Object);

            var result = await service.GetRecipesByIngredients(new List<int> { 1, 2 });

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Pizza", result[0].Name);
        }

        [TestMethod]
        public async Task AddIngredientToRecipe_ReturnsUpdatedRecipeDto()
        {
            var mockRecipeIngredientRepository = new Mock<IRecipeIngredientRepository>();
            var mockRecipeRepository = new Mock<IRecipeRepository>();

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

            var service = new RecipeIngredientService(mockRecipeIngredientRepository.Object, mockRecipeRepository.Object);

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
