using Microsoft.AspNetCore.Mvc;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeIngredientService recipeIngredientService;
        private readonly IRecipeRepository recipeRepository;

        public RecipeController(IRecipeIngredientService recipeIngredientService, IRecipeRepository recipeRepository)
        {
            this.recipeIngredientService = recipeIngredientService ?? throw new ArgumentNullException(nameof(recipeIngredientService));
            this.recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        [HttpGet("all-by-ingredients")]
        public async Task<ActionResult<List<RecipeDto>>> GetRecipesByIngredients([FromQuery] List<int> ingredientIds)
        {
            var recipes = await recipeIngredientService.GetRecipesByIngredients(ingredientIds);
            return Ok(recipes);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<RecipeDto>>> GetAllRecipes()
        {
            var recipes = await recipeRepository.GetAll();
            return Ok(recipes);
        }
    }
}