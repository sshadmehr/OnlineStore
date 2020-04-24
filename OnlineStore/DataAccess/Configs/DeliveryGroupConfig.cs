using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Configs
{
	public class DeliveryGroupConfig : IEntityTypeConfiguration<DeliveryGroup>
	{
		public void Configure(EntityTypeBuilder<DeliveryGroup> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Name)
							.IsRequired()
							.HasColumnType("nvarchar(128)");
		}
	}
}
