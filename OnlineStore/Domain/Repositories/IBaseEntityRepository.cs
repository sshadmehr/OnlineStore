using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.Domain.Respsitories
{
	public interface IBaseEntityRepository<TEntity> where TEntity : class
	{
		TEntity Get(object id);
		IEnumerable<TEntity> Get(string query, params object[] parameters);
		IEnumerable<TEntity> Get(
		Expression<Func<TEntity, bool>> filter = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		string includeProperties = "");

		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		void Delete(object id);

	}
}
