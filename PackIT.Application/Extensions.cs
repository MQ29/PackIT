using Microsoft.Extensions.DependencyInjection;
using PackIT.Domain.Entities;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(x => x.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(x => x.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
