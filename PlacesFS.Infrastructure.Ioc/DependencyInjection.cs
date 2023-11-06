using PlacesFS.Application.Services;
using PlacesFS.Application.Services.Contracts;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Infrastructure.Data.Context;
using PlacesFS.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using PlacesFS.Application.Mapping;

namespace PlacesFS.Infrastructure.Ioc
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
		{
			#region DataBaseConnection
			services.AddDbContext<DataBaseContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("PlacesFSDatabase"));
			});
            #endregion

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            AddServices(services);
			AddRepositories(services);
			return services;
		}
		private static void AddServices(IServiceCollection services)
		{
			services.AddScoped<IPlacesService, PlacesService>();
            services.AddScoped<IFavoritePlaceService, FavoritePlaceService>();
        }
		private static void AddRepositories(IServiceCollection services)
		{
			services.AddHttpClient<IFourSquareClientRepository, FourSquareClientRepository>();
            services.AddScoped<IFavoritePlaceRepository, FavoritePlaceRepository>();
        }

	}
}
