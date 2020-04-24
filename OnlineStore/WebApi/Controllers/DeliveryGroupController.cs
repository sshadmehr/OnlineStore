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
	public class DeliveryGroupController : ControllerBase
	{
		private readonly IDeliveryGroupService _deliveryGroupService;
		private readonly IMapper _mapper;
		public DeliveryGroupController(IDeliveryGroupService deliveryGroupService, IMapper mapper)
		{
			_deliveryGroupService = deliveryGroupService;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<DeliveryGroupModel>> GetAll()
		{
			try
			{
				var result = _deliveryGroupService.GetAll();
				DeliveryGroupModel[] deliveryGroups = _mapper.Map<DeliveryGroupModel[]>(result);
				return deliveryGroups;
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
				_deliveryGroupService.Delete(id);
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		[HttpGet]
		public ActionResult<DeliveryGroupModel> Get(int id)
		{
			try
			{
				var result = _deliveryGroupService.Get(id);
				if (result == null)
					return NotFound();
				else
					return _mapper.Map<DeliveryGroupModel>(result);
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		// Use Ids smaller than one to add new deliveryGroup. 
		[HttpPost]
		public ActionResult<bool> Save([FromBody]DeliveryGroupModel deliveryGroup)
		{
			try
			{
				_deliveryGroupService.Submit(_mapper.Map<DeliveryGroup>(deliveryGroup));
				return true;
			}
			catch (Exception exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
	}
}