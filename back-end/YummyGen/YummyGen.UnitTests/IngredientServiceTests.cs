using Moq;
using YummyGen.Application;
using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.UnitTests
{
    [TestClass]
    public class IngredientServiceTests
    {
        [TestMethod]
        public async Task GetAllIngredients_ReturnsListOfIngredientDtos()
        {
            var mockRepository = new Mock<IIngredientRepository>();
            var sampleIngredients = new List<Ingredient>
            {
                new Ingredient { Id = 1, Name = "Salt" },
                new Ingredient { Id = 2, Name = "Sugar" }
            };
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(sampleIngredients);

            var service = new IngredientService(mockRepository.Object);

            var result = await service.GetAllIngredients();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Salt", result[0].Name);
            Assert.AreEqual("Sugar", result[1].Name);
        }

        [TestMethod]
        public async Task AddIngredient_ReturnsAddedIngredientDto()
        {
            var mockRepository = new Mock<IIngredientRepository>();
            var ingredientToAdd = new AddIngredientDto { Name = "Flour" };
            var addedIngredient = new Ingredient { Id = 1, Name = "Flour" };
            mockRepository.Setup(repo => repo.Add(It.IsAny<Ingredient>())).ReturnsAsync(addedIngredient);

            var service = new IngredientService(mockRepository.Object);

            var result = await service.AddIngredient(ingredientToAdd);

            Assert.IsNotNull(result);
            Assert.AreEqual("Flour", result.Name);
        }
    }
}