using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyGen.Application;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IFilePathsService _filePathsService;
		private readonly IImageService _imageService;

		public ImagesController(IFilePathsService filePathsService, IImageService imageService)
		{
			_filePathsService = filePathsService ?? throw new ArgumentNullException(nameof(filePathsService));
			_imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
		}

		// GET: api/<ImagesController>
		[HttpGet("{imageId}")]
		public async Task<ActionResult> GetById(int imageId)
		{
			var imageDto = await _imageService.GetById(imageId);
			if (imageDto == null)
			{
				return NotFound();
			}

			string imagePath = Path.Combine(_filePathsService.AbsolutePathToImages, $"{imageDto.Id}.{imageDto.Format}");

			if (System.IO.File.Exists(imagePath))
			{
				byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

				return File(imageBytes, $"image/{imageDto.Format}");
			}
			return StatusCode(500);
		}

		[HttpPost]
		public async Task<IActionResult> AddImage([FromForm] AddImageDto addImageDto)
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

					return Ok(filePath);
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
