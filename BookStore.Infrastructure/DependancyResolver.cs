using BookStore.Domain.Repositories;
using BookStore.Domain.Services;
using BookStore.Infrastructure.Persistence;
using BookStore.Infrastructure.Persistence.Repositories;
using BookStore.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class DependancyResolver
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //add dependancies
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FintranetConnectionString"));
            });
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorDomainService, AuthorDomainService>();
            services.AddTransient<IBookDomainService, BookDomainService>();

            return services;
        }
    }
}