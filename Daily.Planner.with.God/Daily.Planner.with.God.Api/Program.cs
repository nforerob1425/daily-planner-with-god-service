using Microsoft.EntityFrameworkCore;
using Daily.Planner.with.God.Persistance;
using Daily.Planner.with.God.Persistance.Interfaces;
using Daily.Planner.with.God.Persistance.Repositories;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;
using AutoMapper;
using Daily.Planner.with.God.Application.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdsRepository, AdsRepository>();
        services.AddScoped<IAgendaRepository, AgendaRepository>();
        services.AddScoped<IColorPalettRepository, ColorPalettRepository>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IPetitionRepository, PetitionRepository>();
        services.AddScoped<IPetitionTypeRepository, PetitionTypeRepository>();
        services.AddScoped<IApplicationConfigRepository, ApplicationConfigRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();

        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdsService, AdsService>();
        services.AddScoped<IAgendaService, AgendaService>();
        services.AddScoped<IColorPalettService, ColorPalettService>();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRolService, RolService>();
        services.AddScoped<ITypeService, TypeService>();
        services.AddScoped<IPetitionService, PetitionService>();
        services.AddScoped<IPetitionTypesService, PetitionTypesService>();
        services.AddScoped<IApplicationConfigServices, ApplicationConfigServices>();
        services.AddScoped<INoteService, NoteService>();

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Daily Planner with God API", Version = "v1" });

            // Define the security scheme
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            // Add the security requirement
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
       {
           {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   }
               },
               new string[] {}
           }
       });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Daily Planner with God API v1");
            });
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}