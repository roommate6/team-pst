using Microsoft.EntityFrameworkCore;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
	public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
	{
		public IngredientRepository(ApplicationDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Ingredient>> GetAllWithIncludings()
		{
			return await context.Set<Ingredient>().Include(i => i.Image).ToListAsync();
		}

		public async Task<Ingredient> GetIngredientByIdWithIncludings(int id)
		{
			return await context.Set<Ingredient>().Include(i => i.Image).FirstAsync(i => i.Id == id);
		}
	}
}
