﻿using Microsoft.EntityFrameworkCore;
using YummyGen.Application;
using YummyGen.DataAccess;
using YummyGen.DataAccess.Repositories;
using YummyGen.Domain.Interfaces;

namespace YummyGenAPI
{
    public class Startup
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

            builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();

        }
    }
}
