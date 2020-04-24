using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Services;
using OnlineStore.WebApi.ViewModels;

namespace OnlineStore.WebApi.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			 _productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ProductModel>> GetAll()
		{
			try
			{
				var result = _productService.GetAll();
				ProductModel[] products = _mapper.Map<ProductModel[]>(result);
				return products;
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
				_productService.Delete(id);
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		[HttpGet]
		public ActionResult<ProductModel> Get(int id)
		{
			try
			{
				var result = _productService.Get(id);
				if (result == null)
					return NotFound();
				else
					return _mapper.Map<ProductModel>(result);
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		// Use Ids smaller than one to add new product. 
		[HttpPost]
		public ActionResult<bool> Save([FromBody]ProductModel product)
		{
			try
			{
				_productService.Submit(_mapper.Map<Product>(product));
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
	}
}