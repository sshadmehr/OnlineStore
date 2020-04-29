using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.DataAccess.Configs
{
	public class TariffConfig : IEntityTypeConfiguration<Tariff>
	{
		public void Configure(EntityTypeBuilder<Tariff> builder)
		{
			builder.HasKey(t => new { t.DeliveryGroupId, t.DeliveryType, t.EffectiveDate });
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(t => t.Price)
							.IsRequired();
			builder.Property(t => t.EffectiveDate)
							.IsRequired()
							.HasColumnType("datetime2(7)");
		}
	}
}
