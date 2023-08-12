using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Infrastructure.Database;
using PersonalBlog.Infrastructure.Database.Repositories;

namespace PersonalBlog.Infrastructure.Extensions;
public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		var provider = services.BuildServiceProvider();
		var configuration = provider.GetRequiredService<IConfiguration>();
		var sqlServerConnectionString = configuration.GetConnectionString("SqlServerConnectionString");
		
		services.AddDbContextFactory<DatabaseContext>(options =>
		{
			options.UseSqlServer(sqlServerConnectionString);
			options.EnableSensitiveDataLogging(false);
		}).AddSqlServer<DatabaseContext>(sqlServerConnectionString);

		//services.AddScoped<DatabaseContext>();
		//services.AddScoped<DbContext, DatabaseContext>();
		services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

		return services;
	}
}