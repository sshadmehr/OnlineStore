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
	public class TariffController : ControllerBase
	{
		private readonly ITariffService _tariffService;
		private readonly IMapper _mapper;
		public TariffController(ITariffService tariffService, IMapper mapper)
		{
			 _tariffService = tariffService;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<TariffModel>> GetAll()
		{
			try
			{
				var result = _tariffService.GetAll();
				TariffModel[] tariffs = _mapper.Map<TariffModel[]>(result);
				return tariffs;
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
				_tariffService.Delete(id);
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		[HttpGet]
		public ActionResult<TariffModel> Get(int id)
		{
			try
			{
				var result = _tariffService.Get(id);
				if (result == null)
					return NotFound();
				else
					return _mapper.Map<TariffModel>(result);
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		// Use Ids smaller than one to add new Tariff. 
		[HttpPost]
		public ActionResult<bool> Save([FromBody]TariffModel tariff)
		{
			try
			{
				_tariffService.Submit(_mapper.Map<Tariff>(tariff));
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
	}
}