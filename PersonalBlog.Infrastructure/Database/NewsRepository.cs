using PersonalBlog.Domain.Entities;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Infrastructure.Database.Repositories;

namespace PersonalBlog.Infrastructure.Database;
public class NewsRepository : BaseRepository<News>, INewsRepository
{
	public NewsRepository(DatabaseContext context) : base(context)
	{
	}
}