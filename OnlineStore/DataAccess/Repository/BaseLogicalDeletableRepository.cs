using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repository
{
	public class BaseLogicalDeletableRepository<TEntity>: BaseEntityRepository<TEntity> where TEntity: class, ILogicalDeletable
	{
		public BaseLogicalDeletableRepository(OnlineStoreContext context): base(context)
		{

		}

		public override void Delete(TEntity entity)
		{
			entity.Deleted = true;
			Update(entity);
		}

		public override void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			entityToDelete.Deleted = true;
			Update(entityToDelete);
		}
	}
}
