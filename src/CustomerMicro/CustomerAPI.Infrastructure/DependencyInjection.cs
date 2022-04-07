using CustomerAPI.Core.Entities;
using CustomerAPI.Core.Interfaces;
using CustomerAPI.Infrastructure.Persistence.Contexts;
using CustomerAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CustomerAPI.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddIdentity<Customer, CustomerRole>(setup =>
            {
                setup.Password.RequiredLength = 6;
                setup.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
            catch
            {
            }

            return services;
        }
    }
}
