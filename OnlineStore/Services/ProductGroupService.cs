using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
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
			if (DeleteValidate(productGroup.Id, out List<string> messagaes))
			{
				_productGroupRepository.Delete(productGroup);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		public void Delete(int id)
		{
			if (DeleteValidate(id, out List<string> messagaes))
			{
				_productGroupRepository.Delete(id);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
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
			if (SubmitValidate(productGroup, out List<string> messagaes))
			{
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
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		private bool SubmitValidate(ProductGroup productGroup, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (string.IsNullOrEmpty(productGroup.Name))
				messagaes.Add("Product Name Can't be emty.");

			if (productGroup.ParentId.HasValue && !_productGroupRepository.ProductGroupExist(productGroup.ParentId.Value))
				messagaes.Add("Product Group Parent Is Invalid.");

			if (_productGroupRepository.IsNameDuplicated(productGroup))
				messagaes.Add("Product Group Name Is Duplicate.");

			return messagaes.Count < 1;
		}

		private bool DeleteValidate(int id, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (_productRepository.IsProductGroupUsed(id))
				messagaes.Add("ProductGroup Is Used In Products And Can't Be Deleted.");

			return true;
		}
	}
}
