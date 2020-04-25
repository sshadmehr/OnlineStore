﻿using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace OnlineStore.Services
{
	public class ProductService : IProductService
	{

		public ProductService(
			IProductRepository productRepository,
			IProductsDeliveryGroupsRepository productsDeliveryGroupsRepository,
			ITariffRepository tariffRepository,
			IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_productsDeliveryGroupsRepository = productsDeliveryGroupsRepository;
			_tariffRepository = tariffRepository;
			_unitOfWork = unitOfWork;
		}
		private readonly IProductRepository _productRepository;
		private readonly IProductsDeliveryGroupsRepository _productsDeliveryGroupsRepository;
		private readonly ITariffRepository _tariffRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(Product product)
		{
			_productRepository.Delete(product);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{

			_productRepository.Delete(id);
			_unitOfWork.Commit();
		}

		public Product Get(int id)
		{
			return _productRepository.Load(id);
		}

		public IEnumerable<Product> GetAll(bool includeDeleted = false)
		{
			var result = new List<Product>();

			if (includeDeleted)
				result = _productRepository.Get()?.ToList();
			else
				result = _productRepository.Get(dg => dg.Deleted == includeDeleted)?.ToList();

			return result;
		}

		public void Submit(Product product)
		{
			using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
			{
				if (product.Id > 0)
				{
					var oldData = _productsDeliveryGroupsRepository.GetByPtoduct(product.Id)?.ToList();
					_productsDeliveryGroupsRepository.DeleteRange(oldData);
					_unitOfWork.Commit();
					_productsDeliveryGroupsRepository.InsertRange(product.ProductsDeliveryGroups);
					_productRepository.Update(product);
				}
				else
				{
					_productRepository.Insert(product);
					_unitOfWork.Commit();

					product.ProductsDeliveryGroups.Select(item => item.ProductId = product.Id);
					_productsDeliveryGroupsRepository.InsertRange(product.ProductsDeliveryGroups);
					
				}
				_unitOfWork.Commit();
				scope.Complete();
			}
		}

		public int GetMinimumProductTariff(int productId)
		{
			return _tariffRepository.GetMinTariff(productId);
		}
		public IEnumerable<Tariff> GetProductTariffList(IEnumerable<int> ids)
		{
			return _tariffRepository.GetProductTariffList(ids);
		}
		
	}
}
