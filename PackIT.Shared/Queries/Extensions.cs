﻿using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(x => x.FromAssemblies(assembly)
                .AddClasses(x => x.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
