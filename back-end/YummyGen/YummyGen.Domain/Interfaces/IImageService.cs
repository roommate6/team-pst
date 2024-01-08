using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
	public interface IImageService
	{
		Task<ImageDto> GetById(int id);
		Task<ImageDto> AddImage(AddImageDto addImageDto);
	}
}
