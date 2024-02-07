using CleanArchMvc.Infra.Ioc;

namespace CleanArchMvc.WebUI
{
   class Startup
   {
       public Startup(IConfiguration configuration)
       {
            Configuration = configuration;
      }
       public IConfiguration Configuration { get; }

       public void ConfigureServices(IServiceCollection services)
       {
           services.AddInfrastructure(Configuration);
           services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if(environment.IsDevelopment()) { 
            
               app.UseDeveloperExceptionPage();
            
           }         
       }
    }
}

