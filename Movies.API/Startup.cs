using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Movies.Application.Handlers.CommandHandlers;
using Movies.Core.Repositories;
using Movies.Core.Repositories.Base;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories;
using Movies.Infrastructure.Repositories.Base;
using System;
using System.Reflection;

namespace Movies.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Activate a healthCheck un route /hc
            services.AddHealthChecks();

            //generate extension methods to minimize code in ConfigureService
            services.AddCustomOptionsServices(Configuration)
                .AddCustomDbContext(Configuration);

            services.AddControllers();

            //Activate cors to allow angular project
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Activate swagger to see api documentation
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Activa cors
            // Use the CORS policy
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //Map healthCheck in endpoints
                endpoints.MapHealthChecks("/hc");
            });
            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            //Imports a services factory to get DbContext instance and apply migrations
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope()
            )
            {
                //Getting logger instance
                var logger = serviceScope.ServiceProvider.GetService<ILogger<MoviesContext>>();

                using (var context = serviceScope.ServiceProvider.GetRequiredService<MoviesContext>())
                {
                    context.Database.Migrate();
                    logger.LogInformation($"Database migration success.");
                }
            }
        }
    }


    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddCustomOptionsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies.API", Version = "v1" });
            });

            //Map Automapper
            services.AddAutoMapper(typeof(Startup));
            //Handle instance MediatR
            services.AddMediatR(typeof(CreateMovieHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateActorHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Create and dependency injection of repository
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IRelationRepository, RelationRepository>();

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure ConnectionString to connect database and some configurations
            services.AddDbContextPool<MoviesContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            });
            return services;
        }

    }
}
