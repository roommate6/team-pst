using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
	public class ImageService : IImageService
	{
		private readonly IImageRepository _imageRepository;

		public ImageService(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public async Task<ImageDto> GetById(int id)
		{
			var image = await _imageRepository.GetById(id);
			if (image == null)
			{
				return null;
			}
			var imageDto = Mapper.ToImageDto(image);
			return imageDto;
		}

		public async Task<ImageDto> AddImage(AddImageDto addImageDto)
		{
			if (addImageDto == null)
			{
				return null;
			}

			var image = Mapper.ToImage(addImageDto);
			var addedImage = await _imageRepository.Add(image);
			var result = Mapper.ToImageDto(addedImage);
			return result;
		}
	}
}
