namespace OnlineStore.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly OnlineStoreContext _dbContext;
		public UnitOfWork(OnlineStoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}
	}
}
