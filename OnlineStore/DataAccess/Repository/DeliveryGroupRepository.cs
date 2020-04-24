using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;

namespace OnlineStore.DataAccess.Repository
{
	public class DeliveryGroupRepository : BaseLogicalDeletableRepository<DeliveryGroup>, IDeliveryGroupRepository
	{
		public DeliveryGroupRepository(OnlineStoreContext context) : base(context)
		{

		}

	}
}
