using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Configs
{
	public class ProductsDeliveryGroupsConfig : IEntityTypeConfiguration<ProductsDeliveryGroups>
	{
		public void Configure(EntityTypeBuilder<ProductsDeliveryGroups> builder)
		{
			builder.HasKey(t => new { t.DeliveryGroupId, t.ProductId });
			builder
					.HasOne(pd => pd.Product)
					.WithMany(pd => pd.ProductsDeliveryGroups)
					.HasForeignKey(pd => pd.ProductId);
			builder
					.HasOne(pd => pd.DeliveryGroup)
					.WithMany(pd => pd.ProductsDeliveryGroups)
					.HasForeignKey(pd => pd.DeliveryGroupId);
		}
	}
}
