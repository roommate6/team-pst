using Microsoft.AspNetCore.Mvc;
using YummyGen.Application;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeIngredientService recipeIngredientService;

        public RecipeController(IRecipeIngredientService recipeIngredientService)
        {
            this.recipeIngredientService = recipeIngredientService ?? throw new ArgumentNullException(nameof(recipeIngredientService));
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeDto>>> GetRecipesByIngredients([FromQuery] List<int> ingredientIds)
        {
            var recipes = await recipeIngredientService.GetRecipesByIngredients(ingredientIds);
            return Ok(recipes);
        }
    }
}