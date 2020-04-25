using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using OnlineStore.Domain.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System;

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
			if (DeleteValidate(product.Id, out List<string> messagaes))
			{
				using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
				{
					_productRepository.Delete(product);
					var productsDeliveryGroups = _productsDeliveryGroupsRepository.GetByPtoduct(product.Id)?.ToList();
					_productsDeliveryGroupsRepository.DeleteRange(productsDeliveryGroups);
					_unitOfWork.Commit();
					scope.Complete();
				}
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		public void Delete(int id)
		{
			if (DeleteValidate(id, out List<string> messagaes))
			{
				using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
				{
					_productRepository.Delete(id);
					var productsDeliveryGroups = _productsDeliveryGroupsRepository.GetByPtoduct(id)?.ToList();
					_productsDeliveryGroupsRepository.DeleteRange(productsDeliveryGroups);
					_unitOfWork.Commit();
					scope.Complete();
				}
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
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
			if (SubmitValidate(product, out List<string> messagaes))
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
					}
					_unitOfWork.Commit();
					scope.Complete();
				}
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		public int GetMinimumProductTariff(int productId)
		{
			return _tariffRepository.GetMinTariff(productId);
		}
		public IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> ids)
		{
			return _tariffRepository.GetProductTariffList(ids);
		}

		private bool SubmitValidate(Product product, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (string.IsNullOrEmpty(product.Name))
				messagaes.Add("Product Name Can't be emty.");

			if (product.ProductGroupId < 1)
				messagaes.Add("Product Group Can't be emty.");

			if (product.RegisterDate == null || product.RegisterDate == DateTime.MinValue)
				messagaes.Add("Product Register Date Can't be emty.");

			if (!_productGroupRepository.ProductGroupExist(product.ProductGroupId))
				messagaes.Add("Product Group Is Invalid.");

			if (_productRepository.IsNameDuplicated(product))
				messagaes.Add("Product Name Is Duplicate.");

			return messagaes.Count < 1;
		}

		private bool DeleteValidate(int id, out List<string> messagaes)
		{
			messagaes = new List<string>();
			return true;
		}
	}
}
