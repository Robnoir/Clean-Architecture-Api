using Infrastructure.Database;
using Infrastructure.Services;
using Infrastructure.UserRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MockDatabase>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<CreateTokenService>();

            // Assuming you need to pass IConfiguration to your services
            services.AddSingleton(configuration);

            return services;
        }
    }
}
