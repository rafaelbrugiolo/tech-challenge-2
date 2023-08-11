using Microsoft.EntityFrameworkCore;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Infrastructure.Database.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected readonly DatabaseContext Context;
	protected readonly DbSet<TEntity> DbSet;

	public BaseRepository(DatabaseContext context)
	{
		Context = context;
		DbSet = context.Set<TEntity>();
	}

	public async Task<TEntity> AddAsync(TEntity entity)
	{
		await DbSet.AddAsync(entity);
		return entity;
	}

	public async Task<TEntity?> FindAsync(Guid id)
	{
		return await DbSet.FindAsync(id);
	}

	public TEntity Update(TEntity entity)
	{
		DbSet.Update(entity);
		return entity;
	}

	public async Task DeleteAsync(Guid id)
	{
		var entity = await DbSet.FindAsync(id);
		if (entity is not null)
			DbSet.Remove(entity);
	}

	public IEnumerable<TEntity> List()
	{
		return DbSet.AsNoTracking().AsQueryable();
	}

	public async Task<int> SaveChangesAsync()
	{
		return await Context.SaveChangesAsync();
	}

	public void Dispose()
	{
		Context?.Dispose();
	}
}