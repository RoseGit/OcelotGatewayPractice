using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotPractice.Aggregators;
using OcelotPractice.Handlers;

namespace OcelotPractice
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //soluciona el bug cuando utilizas un aggregator
            services.AddOcelot().AddDelegatingHandler<RemoveEncodingDelegatingHandler>(true)
                .AddSingletonDefinedAggregator<UsersPostsAggregator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot().Wait();
        }
    }
}
