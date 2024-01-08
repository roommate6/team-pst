using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyGen.Domain.Interfaces
{
	public interface IFilePathsService
	{
		public string RelativePathToImages { get; set; }
		public string AbsolutePathToImages { get; }
	}
}
