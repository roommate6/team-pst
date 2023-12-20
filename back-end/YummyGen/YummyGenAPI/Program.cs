using YummyGenAPI;

var builder = WebApplication.CreateBuilder(args);

var originsName = "frontEndOrigins";
var originsUrl = "http://localhost.com:4200";
Startup.RegisterServices(builder, originsName, originsUrl);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(originsName);

app.UseAuthorization();

app.MapControllers();

app.Run();
