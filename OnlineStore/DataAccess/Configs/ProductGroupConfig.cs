using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.DataAccess.Configs
{
	public class ProductGroupConfig : IEntityTypeConfiguration<ProductGroup>
	{
		public void Configure(EntityTypeBuilder<ProductGroup> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Name)
							.IsRequired()
							.HasMaxLength(128);
		}
	}
}
