using Microsoft.EntityFrameworkCore;
using Daily.Planner.with.God.Persistance;
using Daily.Planner.with.God.Persistance.Interfaces;
using Daily.Planner.with.God.Persistance.Repositories;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;

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
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Daily.Planner.with.God.Persistance")));

        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdsRepository, AdsRepository>();
        services.AddScoped<IAgendaRepository, AgendaRepository>();
        services.AddScoped<IColorPalettRepository, ColorPalettRepository>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();

        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdsService, AdsService>();
        services.AddScoped<IAgendaService, AgendaService>();
        services.AddScoped<IColorPalettService, ColorPalettService>();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRolService, RolService>();
        services.AddScoped<ITypeService, TypeService>();

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