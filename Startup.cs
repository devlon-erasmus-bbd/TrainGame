using TrainGame.Controllers.Config;
using TrainGame.Domain.Services;
using TrainGame.Domain.Repository;
using TrainGame.Extensions;
using TrainGame.Services;
using TrainGame.Persistence.Contexts;
using TrainGame.Persistence.Repositories;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TrainGame
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["Authentication:Google:ClientId"] ?? throw new ArgumentNullException("Authentication:Google:ClientId");
                options.ClientSecret = Configuration["Authentication:Google:ClientSecret"] ?? throw new ArgumentNullException("Authentication:Google:ClientSecret");
            });

            services.AddSingleton<ITrainRepository, TrainRepository>();
            services.AddSingleton<IObjectRepository, ObjectRepository>();
            services.AddSingleton<ITrainService, TrainService>();
            services.AddSingleton<IObjectService, ObjectService>();
            services.AddSingleton<IOptionRepository, OptionRepository>();
            services.AddSingleton<IRandomGeneratorService, RandomGeneratorService>();
            services.AddSingleton<IGameService, GameService>();

            services.AddSingleton<IQuestionService, QuestionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwaggerUI();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}