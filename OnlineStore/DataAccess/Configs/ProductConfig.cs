using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Configs
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Name)
							.IsRequired()
							.HasColumnType("nvarchar(128)");
			builder.Property(p => p.RegisterDate)
							.HasColumnType("smalldatetime");
			builder
					.HasOne(p => p.ProductGroup)
					.WithMany(pg => pg.Products)
					.HasForeignKey(p => p.ProductGroupId);
		}
	}
}
