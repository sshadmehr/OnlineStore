using OnlineStore.Domain.Models;

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
