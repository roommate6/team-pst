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
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeIngredientService recipeIngredientService, IRecipeService recipeService)
        {
            this.recipeIngredientService = recipeIngredientService ?? throw new ArgumentNullException(nameof(recipeIngredientService));
            this.recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
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
            var recipes = await recipeService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpPost("add")]
        public async Task<ActionResult<RecipeDto>> AddRecipe([FromBody] AddRecipeDto addRecipeDto)
        {
            var result = await recipeService.AddRecipe(addRecipeDto);
            return Ok(result);
        }

        [HttpPost("add-ingredient")]
        public async Task<ActionResult<RecipeDto>> AddIngredientToRecipe([FromQuery] int ingredientId, [FromQuery] int recipeId)
        {
            var result = await recipeIngredientService.AddIngredientToRecipe(ingredientId, recipeId);
            return Ok(result);
        }
    }
}