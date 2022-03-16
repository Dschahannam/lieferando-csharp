using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lieferando.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public enum ServiceType
        {
            REQUEST,
        }

        public static void BindAllClassesFrom<T>(this IServiceCollection services, ServiceType serviceType) where T : class
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract))
            {
                if (serviceType == ServiceType.REQUEST)
                {
                    services.AddSingleton(typeof(T), type);

                    services.AddTransient(type);
                }
            }
        }
    }
}
