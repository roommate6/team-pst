using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YummyGen.Application;
using YummyGen.DataAccess;
using YummyGen.DataAccess.Repositories;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGenAPI
{
    public class Startup
    {
        public static void RegisterServices(WebApplicationBuilder builder, string originsName, string originsUrl)
        {
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: originsName,
								  policy =>
								  {
									  policy.WithOrigins(originsUrl)
									  .AllowAnyHeader()
									  .AllowAnyMethod()
									  .AllowAnyOrigin();
								  });
			});


			builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

        }
    }
}
