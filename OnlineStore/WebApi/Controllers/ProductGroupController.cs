using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Services;
using OnlineStore.WebApi.ViewModels;

namespace OnlineStore.WebApi.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ProductGroupGroupController : ControllerBase
	{
		private readonly IProductGroupService _productGroupService;
		private readonly IMapper _mapper;
		public ProductGroupGroupController(IProductGroupService productGroupService, IMapper mapper)
		{
			 _productGroupService = productGroupService;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ProductGroupModel>> GetAll()
		{
			try
			{
				var result = _productGroupService.GetAll();
				ProductGroupModel[] productGroups = _mapper.Map<ProductGroupModel[]>(result);
				return productGroups;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}


		[HttpDelete]
		public ActionResult<bool> Delete(int id)
		{
			try
			{
				_productGroupService.Delete(id);
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		[HttpGet]
		public ActionResult<ProductGroupModel> Get(int id)
		{
			try
			{
				var result = _productGroupService.Get(id);
				if (result == null)
					return NotFound();
				else
					return _mapper.Map<ProductGroupModel>(result);
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		// Use Ids smaller than one to add new productGroup. 
		[HttpPost]
		public ActionResult<bool> Save([FromBody]ProductGroupModel productGroup)
		{
			try
			{
				_productGroupService.Submit(_mapper.Map<ProductGroup>(productGroup));
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
	}
}