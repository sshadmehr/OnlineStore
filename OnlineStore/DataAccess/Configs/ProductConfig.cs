using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

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
							.HasMaxLength(128);
			builder.Property(p => p.RegisterDate)
							.HasColumnType("datetime2(7)");
			builder
					.HasOne(p => p.ProductGroup)
					.WithMany(pg => pg.Products)
					.HasForeignKey(p => p.ProductGroupId);
		}
	}
}
