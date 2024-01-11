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
		private readonly IRecipeIngredientService _recipeIngredientService;
		private readonly IRecipeService _recipeService;
		private readonly IImageService _imageService;
		private readonly IFilePathsService _filePathsService;
		private readonly IImageRepository _imageRepository;

		public RecipeController(
			IRecipeIngredientService recipeIngredientService,
			IRecipeService recipeService,
			IImageService imageService,
			IFilePathsService filePathsService,
			IImageRepository imageRepository)
		{
			_recipeIngredientService = recipeIngredientService ?? throw new ArgumentNullException(nameof(recipeIngredientService));
			_recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
			_imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
			_filePathsService = filePathsService ?? throw new ArgumentNullException(nameof(filePathsService));
			_imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<RecipeDto>>> GetRecipeById(int id)
		{
			var recipeDto = await _recipeService.GetRecipeByIdWithIncludings(id);
			if (recipeDto == null)
			{
				return NotFound();
			}

			return Ok(recipeDto);
		}

		[HttpGet("all-by-ingredients-names")]
		public async Task<ActionResult<List<RecipeDto>>> GetRecipesByIngredientsNames([FromQuery] List<string> ingredientsNames)
		{
			var recipes = await _recipeIngredientService.GetRecipesByIngredientsNamesWithIncludings(ingredientsNames);
			return Ok(recipes);
		}

		[HttpGet("all-by-ingredients-ids")]
		public async Task<ActionResult<List<RecipeDto>>> GetRecipesByIngredientsIds([FromQuery] List<int> ingredientsIds)
		{
			var recipes = await _recipeIngredientService.GetRecipesByIngredientsIdsWithIncludings(ingredientsIds);
			return Ok(recipes);
		}

		[HttpGet("all-by-ingredients-ids-exclusive")]
		public async Task<ActionResult<List<RecipeDto>>> GetRecipesByIngredientsIdsExclusive([FromQuery] List<int> ingredientsIds)
		{
			var recipes = await _recipeService.GetRecipeByIngredientsIdsWithIncludings(ingredientsIds);
			return Ok(recipes);
		}

		[HttpGet("all")]
		public async Task<ActionResult<List<RecipeDto>>> GetAllRecipes()
		{
			var recipes = await _recipeService.GetAllRecipesWithIncludings();
			return Ok(recipes);
		}

		[HttpPost("add")]
		public async Task<ActionResult<RecipeDto>> AddRecipe([FromForm] AddRecipeDto addRecipeDto, [FromForm] AddImageDto addImageDto)
		{
			try
			{
				if (addImageDto.ImageFile != null && addImageDto.ImageFile.Length > 0)
				{
					var addedImage = await _imageService.AddImage(addImageDto);

					string fileName = addedImage.Id.ToString() + "." + addedImage.Format;

					string filePath = Path.Combine(_filePathsService.AbsolutePathToImages, fileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await addImageDto.ImageFile.CopyToAsync(stream);
					}

					var image = await _imageRepository.GetById(addedImage.Id);
					var recipeDto = await _recipeService.AddRecipe(addRecipeDto, image);

					return Ok(recipeDto);
				}

				return BadRequest("No image provided in the request.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("add-ingredient")]
		public async Task<ActionResult<RecipeDto>> AddIngredientToRecipe([FromQuery] int ingredientId, [FromQuery] int recipeId)
		{
			var result = await _recipeIngredientService.AddIngredientToRecipeWithIncludings(ingredientId, recipeId);
			return Ok(result);
		}
	}
}