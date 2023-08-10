﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Infrastructure.Database;

namespace PersonalBlog.Infrastructure.Extensions;
public static class ApplicationBuilderExtensions
{
	public static void MigrateDatabase(this IApplicationBuilder app)
	{
		using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
		var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

		if (context.Database.GetPendingMigrations().Any())
			context.Database.Migrate();
	}
}