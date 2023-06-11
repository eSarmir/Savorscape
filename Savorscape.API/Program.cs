using Microsoft.EntityFrameworkCore;
using Savorscape.Database;
using Savorscape.Database.Repositories.IRepository;
using Savorscape.Database.Repositories.Repository;

var DevelopementAllowOrigin = "DevelopementAllowOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(DevelopementAllowOrigin, policy =>
    {
        policy.AllowAnyOrigin();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SavorscapeDbContext>(
    context => context.UseNpgsql(
        builder.Configuration.GetConnectionString("SavorscapeDatabase")));

builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IInstructionRepository, InstructionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseCors(DevelopementAllowOrigin);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
