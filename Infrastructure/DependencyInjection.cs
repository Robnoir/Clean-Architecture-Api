using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseMySql("server=localhost;port=3306;user=root;password=Robert123;database=RealDB",
                         new MySqlServerVersion(new Version(8, 2, 0)));
            });
            return services;

        }

    }
}
