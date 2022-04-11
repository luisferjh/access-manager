using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccessManagerApp.Helpers
{
    public static class StaticServiceProvider
    {

        static IServiceProvider provider;
        public static void GenerarProveedor(IServiceCollection serviceCollection)
        {
            provider = serviceCollection.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return provider.GetService<T>();
        }
    }
}
