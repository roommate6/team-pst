using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyGen.Domain
{
	public class Image : BaseEntity
	{
		public string Format { get; set; } = null!;
		public List<Recipe> Recipes { get; set; } = new();
		public List<Ingredient> Ingredients { get; set; } = new();

	}
}
