using Domain;
using FluentValidation;
using Infrastructure.Database.Repositories.UserRepo;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database.Repositories.AnimalRepo;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddValidatorsFromAssembly(assembly);

            return services;
        }


    }
}
