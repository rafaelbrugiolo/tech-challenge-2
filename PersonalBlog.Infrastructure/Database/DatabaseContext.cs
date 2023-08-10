using Microsoft.EntityFrameworkCore;
using PersonalBlog.Domain.Entities;
using PersonalBlog.Infrastructure.Database.Mappings;

namespace PersonalBlog.Infrastructure.Database;
public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

	public DbSet<News> News { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			relationship.DeleteBehavior = DeleteBehavior.NoAction;

		new NewsMapping().Initialize(modelBuilder.Entity<News>());

		base.OnModelCreating(modelBuilder);
	}
}