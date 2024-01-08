using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
	public class FilePathsService : IFilePathsService
	{
		public string RelativePathToImages { get; set; }
		public string AbsolutePathToImages
		{
			get
			{
				return Path.Combine(Directory.GetCurrentDirectory(), RelativePathToImages);
			}
		}
	}
}
