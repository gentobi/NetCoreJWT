using Microsoft.Extensions.DependencyInjection;
using NetCoreAuth.Infrastructures.Repositories;
using NetCoreAuth.Infrastructures.Services;
using NetCoreAuth.Repositories;
using NetCoreAuth.Services;
using System;

namespace NetCoreAuth.Configurations
{
    public static class DIConfig
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            //1. Register repositories
            services.AddFactory<IUserRepository, UserRepository>();

            //2. Register services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
             where TService : class
             where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(_ => () => _.GetService<TService>());
        }
    }
}
