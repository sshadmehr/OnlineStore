﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Respsitories
{
	public interface IProductsDeliveryGroupsRepository :IBaseEntityRepository<ProductsDeliveryGroups>
	{
		IEnumerable<ProductsDeliveryGroups> GetByPtoduct(int productId);
		IEnumerable<ProductsDeliveryGroups> GetByDeliveryGroup(int deliveryGroupId);
		void Delete(int id);
		void InsertRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups);
		void DeleteRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups);
	}

}