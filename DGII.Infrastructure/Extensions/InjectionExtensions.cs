using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGII.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
 
        public static IServiceCollection AddInjectionInfrastructure ( this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(DgiiPruebaTContext).Assembly.FullName;

     
            services.AddDbContext<DgiiPruebaTContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection"), b => b.MigrationsAssembly(assembly)
                ), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
