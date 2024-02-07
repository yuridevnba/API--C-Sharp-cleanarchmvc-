using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(

                connectionStringMysql,
                ServerVersion.Parse("8.0.30-Mysql Work bench")
                )



            );

            builder.Services.AddInfrastructure(builder.Configuration);//Definir os registros
            // dos serviços e recursos, para poder usar os recursos no webui dos repositórios dos serviços do contexto.
            ////builder.Services.AddInfraDemo(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // arquivo static                  


            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


            /*var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            app.Run();*/

        }
    }
}