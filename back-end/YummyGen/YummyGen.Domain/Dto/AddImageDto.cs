using Microsoft.AspNetCore.Http;

namespace YummyGen.Domain.Dto
{
	public class AddImageDto
	{
		public IFormFile ImageFile { get; set; }
	}
}
