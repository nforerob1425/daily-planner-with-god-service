using Microsoft.EntityFrameworkCore;
using Daily.Planner.with.God.Persistance;
using Microsoft.Extensions.Options;
using Daily.Planner.with.God.Persistance.Interfaces;
using Daily.Planner.with.God.Persistance.Repositories;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;
using Daily.Planner.with.God.Api.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        ConfigureMiddleware(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Configurar Entity Framework Core con PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Daily.Planner.with.God.Persistance")));

        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICardService, CardService>();


        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}