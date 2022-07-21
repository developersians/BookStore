using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application
{
    public static class DependancyResolver
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //add dependencies

            return services;
        }
    }
}