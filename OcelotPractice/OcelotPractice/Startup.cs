using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotPractice.Aggregators;
using OcelotPractice.Handlers;

namespace OcelotPractice
{
    /// <summary>
    /// Responsible for configuring the necessary elements of the program
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// default constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Service configuration.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("YmFzZTY0X2tleV9leGFtcGxlXzEyMzQ1Njc4OTAxMjM0NTY3ODkwMTIzNA==")),

                };
            });

            //soluciona el bug cuando utilizas un aggregator
            services.AddOcelot().AddDelegatingHandler<RemoveEncodingDelegatingHandler>(true)
                .AddDelegatingHandler<BlackListHandler>()
                .AddSingletonDefinedAggregator<UsersPostsAggregator>();
        }

        /// <summary>
        /// Application configuration.
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        /// <param name="env"><see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseOcelot().Wait();
        }
    }
}
