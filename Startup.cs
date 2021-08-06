using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PokemonDeckWinRateAPI.Models.Context;
using PokemonDeckWinRateAPI.Repositories;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.Services;
using PokemonDeckWinRateAPI.Services.Interfaces;

namespace PokemonDeckWinRateAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokemonDeckWinRateAPI", Version = "v1" });
            });

            services.AddDbContext<PokemonDeckWinRateContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));



            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IDeckService, DeckService>();
            services.AddTransient<IDeckRepository, DeckRepository>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IMatchRepository, MatchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokemonDeckWinRateAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
