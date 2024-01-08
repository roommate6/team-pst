using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyGen.Domain.Interfaces;
using YummyGen.Domain;

namespace YummyGen.DataAccess.Repositories
{
	public class ImageRepository : RepositoryBase<Image>, IImageRepository
	{
		public ImageRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
