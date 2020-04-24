using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Respsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.DataAccess.Repository
{
	public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : class
	{
		internal OnlineStoreContext context;
		internal DbSet<TEntity> dbSet;
		public BaseEntityRepository(OnlineStoreContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual void Delete(TEntity entity)
		{
			if (context.Entry(entity).State == EntityState.Detached)
			{
				dbSet.Attach(entity);
			}
			dbSet.Remove(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public TEntity Get(object id)
		{
			return dbSet.Find(id);
		}

		public IEnumerable<TEntity> Get(string query, params object[] parameters)
		{
			return dbSet.FromSqlRaw<TEntity>(query, parameters).ToList();
		}

		public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}


			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}
		public void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}
	}
}
