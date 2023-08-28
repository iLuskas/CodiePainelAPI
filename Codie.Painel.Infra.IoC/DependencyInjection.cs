using Codie.Painel.Application.Mappins;
using Codie.Painel.Application.Services;
using Codie.Painel.Domain.Authentication;
using Codie.Painel.Domain.Repositories;
using Codie.Painel.Infra.Data.Context;
using Codie.Painel.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codie.Painel.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                                                       );

            services.AddScoped<ITokenGenerator, AuthenticationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainMapEntities));
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
