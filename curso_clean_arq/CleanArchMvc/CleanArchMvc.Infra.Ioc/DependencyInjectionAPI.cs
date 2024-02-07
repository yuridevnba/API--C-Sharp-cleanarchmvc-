
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvcApplication.Interfaces;
using CleanArchMvcApplication.Mappings;
using CleanArchMvcApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

      

       

        services.AddScoped<IPessoaRepository, PesssoaRepository>();
        services.AddScoped<IDadosRepository, DadosRepository>();
        services.AddScoped<IDadosService, DadosService>();
        services.AddScoped<IPessoaService, PessoaService>();
        
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
        

        return services;
    }
}