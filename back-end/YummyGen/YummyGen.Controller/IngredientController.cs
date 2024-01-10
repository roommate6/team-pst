using Microsoft.AspNetCore.Mvc;
using YummyGen.Application;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class IngredientController : ControllerBase
	{
		private readonly IIngredientService _ingredientService;
		private readonly IImageService _imageService;
		private readonly IFilePathsService _filePathsService;
		private readonly IImageRepository _imageRepository;
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientController(
			IIngredientService ingredientService,
			IImageService imageService,
			IFilePathsService filePathsService,
			IImageRepository imageRepository,
			IIngredientRepository ingredientRepository)
		{
			_ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
			_imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
			_filePathsService = filePathsService ?? throw new ArgumentNullException(nameof(filePathsService));
			_imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
			_ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IngredientDto>> GetIngredientById(int id)
		{
			var ingredientDto = await _ingredientService.GetIngredientByIdWithIncludings(id);
			if (ingredientDto == null)
			{
				return NotFound();
			}

			return Ok(ingredientDto);
		}

		[HttpGet("all")]
		public async Task<ActionResult<List<IngredientDto>>> GetAllIngredients()
		{
			var ingredients = await _ingredientService.GetAllWithIncludings();
			return Ok(ingredients);
		}

		[HttpPost("add")]
		public async Task<ActionResult<IngredientDto>> AddIngredient([FromForm] AddIngredientDto addIngredientDto, [FromForm] AddImageDto addImageDto)
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
					var ingredientDto = await _ingredientService.AddIngredient(addIngredientDto, image);

					return Ok(ingredientDto);
				}

				return BadRequest("No image provided in the request.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
