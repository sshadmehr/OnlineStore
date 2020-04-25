using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using OnlineStore.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Services
{
	public class ProductGroupService : IProductGroupService
	{
		public ProductGroupService(
			IProductGroupRepository productGroupRepository,
			IProductRepository productRepository,
			IUnitOfWork unitOfWork)
		{
			_productGroupRepository = productGroupRepository;
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly IProductGroupRepository _productGroupRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRepository _productRepository;

		public void Delete(ProductGroup productGroup)
		{
			DeleteValidate(productGroup.Id);
			_productGroupRepository.Delete(productGroup);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			DeleteValidate(id);
			_productGroupRepository.Delete(id);
			_unitOfWork.Commit();
		}

		public ProductGroup Get(int id)
		{
			return _productGroupRepository.Get(id);
		}

		public IEnumerable<ProductGroup> GetAll(bool includeDeleted = false)
		{
			var result = new List<ProductGroup>();

			if (includeDeleted)
				result = _productGroupRepository.Get()?.ToList();
			else
				result = _productGroupRepository.Get(dg => dg.Deleted == includeDeleted)?.ToList();

			return result;
		}

		public void Submit(ProductGroup productGroup)
		{
			SubmitValidate(productGroup);
			if (productGroup.Id > 0)
			{
				_productGroupRepository.Update(productGroup);
			}
			else
			{
				_productGroupRepository.Insert(productGroup);
			}
			_unitOfWork.Commit();
		}

		private bool SubmitValidate(ProductGroup productGroup)
		{
			var messages = new List<string>();

			if (string.IsNullOrEmpty(productGroup.Name))
				messages.Add("Product Name Can't be emty.");

			if (productGroup.ParentId.HasValue && !_productGroupRepository.ProductGroupExist(productGroup.ParentId.Value))
				messages.Add("Product Group Parent Is Invalid.");

			if (_productGroupRepository.IsNameDuplicated(productGroup))
				messages.Add("Product Group Name Is Duplicate.");

			if (messages.Count > 0)
			{
				throw new ApplicationException(messages);
			}

			return true;
		}

		private bool DeleteValidate(int id)
		{
			var messages = new List<string>();

			if (_productRepository.IsProductGroupUsed(id))
				messages.Add("ProductGroup Is Used In Products And Can't Be Deleted.");

			if (messages.Count > 0)
			{
				throw new ApplicationException(messages);
			}

			return true;
		}
	}
}
