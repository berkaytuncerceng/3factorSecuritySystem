using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
	public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
	{
		T Get(Expression<Func<T, bool>> filter);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		List<T> GetAll(Expression<Func<T, bool>> filter);

	}
}
