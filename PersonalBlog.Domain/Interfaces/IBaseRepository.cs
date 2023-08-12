using PersonalBlog.Domain.Entities;

namespace PersonalBlog.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
	Task<TEntity> AddAsync(TEntity entity);
	Task<TEntity?> FindAsync(Guid id);
	TEntity Update(TEntity entity);
	Task DeleteAsync(Guid id);
	IEnumerable<TEntity> List();
	Task<int> SaveChangesAsync();
	void Dispose();
}