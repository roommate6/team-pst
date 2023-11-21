﻿using Microsoft.EntityFrameworkCore;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class RecipeIngredientRepository : RepositoryBase<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<RecipeIngredient>> GetByIngredients(List<int> ingredientsIds)
        {
            var recipeIngredients = await context.RecipeIngredients
                .Where(ri => ingredientsIds.Contains(ri.IngredientId))
                .Include(ri => ri.Recipe)
                .ToListAsync();
            return recipeIngredients;
        }
    }
}
