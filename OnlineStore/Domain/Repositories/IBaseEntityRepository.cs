using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Dtos;

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
	public interface IProductRepository : IBaseEntityRepository<Product>
	{
		Product Load(int id);
		bool IsNameDuplicated(Product product);
	}
	public interface IProductGroupRepository : IBaseEntityRepository<ProductGroup> 
	{
		bool ProductGroupExist(int id);
	}
	public interface IDeliveryGroupRepository : IBaseEntityRepository<DeliveryGroup> { }
	public interface ITariffRepository : IBaseEntityRepository<Tariff>
	{
		int GetMinTariff(int productId);
		IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> productIds);
	}

}
