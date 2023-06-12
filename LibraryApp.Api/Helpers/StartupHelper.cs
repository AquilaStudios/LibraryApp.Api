using LibraryApp.DataAccess;
using LibraryApp.DomainLogic.Interfaces;
using LibraryApp.DomainLogic;
using LibraryApp.Mapper.Mappers;
using LibraryApp.Mapper.Resolvers;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Helpers
{
    public static class StartupHelper
    {
            public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
            {

                var actualConnectionString = configuration.GetConnectionString("BookHive");

                var placeholderConnectionString = configuration.GetConnectionString("BookHive");

                var connectionString = actualConnectionString ?? placeholderConnectionString;

                services.AddDbContext<BookHiveContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddScoped<IDbContext, BookHiveContext>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<MapperResolver>();
                services.AddScoped<ItemMapper>();
                services.AddScoped<IItemRequests, ItemRequests>();
            }
        }
}
