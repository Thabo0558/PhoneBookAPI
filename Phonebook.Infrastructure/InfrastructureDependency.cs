using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Phonebook.API;
using Phonebook.Core.Contracts;
using Phonebook.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration, IOptions<AppSettings> config)
        {
            services.AddDbContext<IPhoneBookContext, PhoneBookContext>();
            services.AddDbContext<PhoneBookContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(config.Value.ConnectionString),
                    c => c.MigrationsAssembly(typeof(PhoneBookContext).Assembly.FullName)));

            return services;
        }
    }
}
