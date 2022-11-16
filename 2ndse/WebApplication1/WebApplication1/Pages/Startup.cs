using Microsoft.AspNetCore.Builder;


namespace WebApplication1.Pages
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
           app.UseEndpoints(x => x.MapRazorPages());
        }

    }
    
}


