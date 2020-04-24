using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
	public class ProductGroupService : IProductGroupService
	{
		public ProductGroupService(IProductGroupRepository productGroupRepository, IUnitOfWork unitOfWork)
		{
			_productGroupRepository = productGroupRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly IProductGroupRepository _productGroupRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(ProductGroup productGroup)
		{
			_productGroupRepository.Delete(productGroup);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{
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
	}
}
