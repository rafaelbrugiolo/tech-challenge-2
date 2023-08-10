using PersonalBlog.Api.Interfaces;
using PersonalBlog.Api.Services;

namespace PersonalBlog.Api.Commom;

public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddTransient<INewsService, NewsService>();

		services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperConfig>());

		return services;
	}
}