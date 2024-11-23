using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
		where TEntity : class, IEntity, new()
		where TContext : DbContext, new()
	{
		public void Add(TEntity entity)
		{
			using (var context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Delete(TEntity entity)
		{
			using (var context = new TContext())
			{
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public TEntity Get(Expression<Func<TEntity, bool>> filter)
		{
			using (var context = new TContext())
			{
				return context.Set<TEntity>().FirstOrDefault(filter);
			}
		}


		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				// Eğer filter null değilse, o zaman filtre uygulanır; değilse tüm veriler döndürülür.
				var query = context.Set<TEntity>().AsQueryable();

				if (filter != null)
				{
					query = query.Where(filter);  // Filtre uygulanır.
				}

				return query.ToList();  // Son olarak, veriler listeye dönüştürülür.
			}
		}


		public void Update(TEntity entity)
		{
			using (var context = new TContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
