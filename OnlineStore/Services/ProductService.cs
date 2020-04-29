using OnlineStore.DataAccess;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace OnlineStore.Services
{
	public class ProductService : IProductService
	{

		public ProductService(
			IProductRepository productRepository,
			IProductGroupRepository productGroupRepository,
			IProductsDeliveryGroupsRepository productsDeliveryGroupsRepository,
			ITariffRepository tariffRepository,
			IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_productGroupRepository = productGroupRepository;
			_productsDeliveryGroupsRepository = productsDeliveryGroupsRepository;
			_tariffRepository = tariffRepository;
			_unitOfWork = unitOfWork;
		}
		private readonly IProductRepository _productRepository;
		private readonly IProductGroupRepository _productGroupRepository;
		private readonly IProductsDeliveryGroupsRepository _productsDeliveryGroupsRepository;
		private readonly ITariffRepository _tariffRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(Product product)
		{
			using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
			{
				_productRepository.Delete(product);
				var productsDeliveryGroups = _productsDeliveryGroupsRepository.GetByProduct(product.Id)?.ToList();
				_productsDeliveryGroupsRepository.DeleteRange(productsDeliveryGroups);
				_unitOfWork.Commit();
				scope.Complete();
			}
		}

		public void Delete(int id)
		{
			using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
			{
				_productRepository.Delete(id);
				var productsDeliveryGroups = _productsDeliveryGroupsRepository.GetByProduct(id)?.ToList();
				_productsDeliveryGroupsRepository.DeleteRange(productsDeliveryGroups);
				_unitOfWork.Commit();
				scope.Complete();
			}
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
			SubmitValidate(product);
			using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
			{
				if (product.Id > 0)
				{

					var oldData = _productsDeliveryGroupsRepository.GetByProduct(product.Id)?.ToList();
					_productsDeliveryGroupsRepository.DeleteRange(oldData);
					_unitOfWork.Commit();
					_productsDeliveryGroupsRepository.InsertRange(product.ProductsDeliveryGroups);
					_productRepository.Update(product);

				}
				else
				{
					_productRepository.Insert(product);
				}
				_unitOfWork.Commit();
				scope.Complete();
			}
		}

		public int GetMinimumProductTariff(int productId)
		{
			return _tariffRepository.GetMinTariff(productId);
		}
		public IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> ids)
		{
			return _tariffRepository.GetProductTariffList(ids);
		}

		private void SubmitValidate(Product product)
		{
			var messages = new List<string>();

			if (string.IsNullOrEmpty(product.Name))
				messages.Add("Product Name Can't be emty.");

			if (product.ProductGroupId < 1)
				messages.Add("Product Group Can't be emty.");

			if (product.RegisterDate == null || product.RegisterDate == DateTime.MinValue)
				messages.Add("Product Register Date Can't be emty.");

			if (!_productGroupRepository.ProductGroupExist(product.ProductGroupId))
				messages.Add("Product Group Is Invalid.");

			if (_productRepository.IsNameDuplicated(product))
				messages.Add("Product Name Is Duplicate.");

			if (messages.Count > 0)
			{
				throw new Exceptions.ApplicationException(messages);
			}
		}
	}
}
