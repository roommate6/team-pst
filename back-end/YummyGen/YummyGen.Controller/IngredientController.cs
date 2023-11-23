using Microsoft.AspNetCore.Mvc;
using YummyGen.Application;
using YummyGen.Domain.Dto;

namespace YummyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<IngredientDto>>> GetAllIngredients()
        {
            var ingredients = await ingredientService.GetAllIngredients();
            return Ok(ingredients);
        }

        [HttpPost("add")]
        public async Task<ActionResult<IngredientDto>> AddIngredient([FromBody] AddIngredientDto ingredientDto)
        {
            var ingredient = await ingredientService.AddIngredient(ingredientDto);
            return Ok(ingredient);
        }
    }
}
