using PersonalBlog.Domain.Entities;

namespace PersonalBlog.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
	void Insert(TEntity entity);
	TEntity? Get(Guid id);
	void Update(TEntity entity);
	void Delete(Guid id);
	IEnumerable<TEntity> List();
	int SaveChanges();
	void Dispose();
}