using YummyGen.Domain;
using YummyGen.Domain.Dto;

namespace YummyGen.Application
{
	public static class Mapper
	{
		public static RecipeDto ToRecipeDto(Recipe recipe)
		{
			var recipeDto = new RecipeDto
			{
				Id = recipe.Id,
				Name = recipe.Name,
				ShortDescription = recipe.ShortDescription,
			};

			if (recipe.Ingredients != null)
			{
				recipeDto.Ingredients = recipe.Ingredients.Select(i => ToIngredientDto(i)).ToList();
			}

			return recipeDto;
		}

		public static Recipe ToRecipe(AddRecipeDto recipe)
		{
			return new Recipe
			{
				Name = recipe.Name,
				ShortDescription = recipe.ShortDescription
			};
		}

		public static IngredientDto ToIngredientDto(Ingredient ingredient)
		{
			return new IngredientDto
			{
				Id = ingredient.Id,
				Name = ingredient.Name
			};
		}

		public static Ingredient ToIngredient(AddIngredientDto ingredient)
		{
			return new Ingredient
			{
				Name = ingredient.Name
			};
		}

		public static User ToUser(RegisterDto userDto)
		{
			return new User
			{
				UserName = userDto.UserName,
				FirstName = userDto.FirstName,
				LastName = userDto.LastName,
			};
		}

		public static UserDto ToUserDto(User user)
		{
			return new UserDto
			{
				Id = user.Id,
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
			};
		}

		public static ImageDto ToImageDto(Image image)
		{
			return new ImageDto
			{
				Id = image.Id,
				Format = image.Format,
			};
		}

		public static Image ToImage(AddImageDto addImageDto)
		{
			return new Image
			{
				Format = Path.GetExtension(addImageDto.ImageFile.FileName)[1..]
			};
		}
	}
}
