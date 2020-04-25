using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Configs;
using OnlineStore.Domain.Models;

namespace OnlineStore.DataAccess
{
	public class OnlineStoreContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"server=.;database=OnlineStore;User ID=Test;password=1qaz!QAZ;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfig());
			modelBuilder.ApplyConfiguration(new ProductGroupConfig());
			modelBuilder.ApplyConfiguration(new DeliveryGroupConfig());
			modelBuilder.ApplyConfiguration(new TariffConfig());
			modelBuilder.ApplyConfiguration(new ProductsDeliveryGroupsConfig());
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductGroup> ProductGroups { get; set; }
		public DbSet<DeliveryGroup> DeliveryGroups { get; set; }
		public DbSet<Tariff> Tariffs { get; set; }
		public DbSet<ProductsDeliveryGroups> ProductsDeliveryGroups { get; set; }
	}
}
